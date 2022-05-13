public class Twitter
{
    Dictionary<int, HashSet<int>> followDict;
    Dictionary<int, List<KeyValuePair<int, int>>> tweetDict;
    int globalTime;
    public Twitter()
    {
        followDict = new Dictionary<int, HashSet<int>>();
        tweetDict = new Dictionary<int, List<KeyValuePair<int, int>>>();
        globalTime = 0;
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (!tweetDict.ContainsKey(userId))
            tweetDict[userId] = new List<KeyValuePair<int, int>>();
        tweetDict[userId].Add(new KeyValuePair<int, int>(tweetId, globalTime++));
    }

    public IList<int> GetNewsFeed(int userId)
    {
        // add the tail/most recent of every tweet list of both followees and self
        var pq = new PriorityQueue<Tuple<int, int, int, int>, int>();
        var followeeIds = followDict.GetValueOrDefault(userId, new HashSet<int>());
        // include user itself
        followeeIds.Add(userId);
        foreach (var followeeId in followeeIds)
        {
            if (!tweetDict.ContainsKey(followeeId))
                continue;
            var tweetList = tweetDict[followeeId];
            var lastIndex = tweetList.Count - 1;
            if (lastIndex < 0)
                continue;
            var tweetId = tweetList.Last().Key;
            var time = tweetList.Last().Value;
            var element = new Tuple<int, int, int, int>(followeeId, lastIndex, tweetId, time);
            pq.Enqueue(element, -time);
        }

        var feed = new List<int>();
        while (pq.Count != 0 && feed.Count < 10)
        {
            var element = pq.Dequeue();
            var followeeId = element.Item1;
            var index = element.Item2;
            var tweetId = element.Item3;
            var time = element.Item4;
            feed.Add(tweetId);

            // add next element to PQ
            index--;
            if (index < 0)
                continue;
            tweetId = tweetDict[followeeId][index].Key;
            time = tweetDict[followeeId][index].Value;
            var newElement = new Tuple<int, int, int, int>(followeeId, index, tweetId, time);
            pq.Enqueue(newElement, -time);
        }

        return feed;
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!followDict.ContainsKey(followerId))
            followDict[followerId] = new HashSet<int>();
        followDict[followerId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (!followDict.ContainsKey(followerId))
            return;
        followDict[followerId].Remove(followeeId);
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */

var s = new Twitter();
s.PostTweet(1, 5);
var feed = s.GetNewsFeed(1);
Console.WriteLine(feed);