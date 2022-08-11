
public class Twitter
{
    // Space: O(m + n)
    // m: number of users, n: number of tweets
    private int globalTime;
    private Dictionary<int, User> userDict;
    public Twitter()
    {
        userDict = new Dictionary<int, User>();
        globalTime = 0;
    }

    // Time: O(1)
    public void PostTweet(int userId, int tweetId)
    {
        if (!userDict.ContainsKey(userId))
            userDict[userId] = new User(userId);
        userDict[userId].PostTweet(tweetId, globalTime++);
    }

    // Time: O(log m)
    // Space: O(log m)
    public IList<int> GetNewsFeed(int userId)
    {
        if (!userDict.ContainsKey(userId))
            userDict[userId] = new User(userId);

        var followeeIds = userDict[userId].FolloweeIdSet;
        var feed = new List<int>();
        var pq = new PriorityQueue<Tweet, int>(); // max heap, time
        // add all linked list heads into pq, including itself
        followeeIds.Add(userId);
        foreach (var followeeId in followeeIds)
        {
            var tweetList = userDict[followeeId].TweetList;
            if (tweetList.Count == 0)
                continue;
            Tweet mostRecent = tweetList.First.Value;
            pq.Enqueue(mostRecent, -mostRecent.Time);
        }
        while (feed.Count < 10 && pq.Count != 0)
        {
            var tweet = pq.Dequeue();
            feed.Add(tweet.Id);
            var nextTweet = tweet.Next;
            if (nextTweet != null)
                pq.Enqueue(nextTweet, -nextTweet.Time);
        }

        return feed;
    }

    // Time: O(1)
    public void Follow(int followerId, int followeeId)
    {
        if (!userDict.ContainsKey(followerId))
            userDict[followerId] = new User(followerId);
        if (!userDict.ContainsKey(followeeId))
            userDict[followeeId] = new User(followeeId);

        userDict[followerId].Follow(followeeId);
    }

    // Time: O(1)
    public void Unfollow(int followerId, int followeeId)
    {
        if (!userDict.ContainsKey(followerId))
            return;
        if (!userDict.ContainsKey(followeeId))
            return;

        userDict[followerId].Unfollow(followeeId);
    }
}

public class Tweet
{
    public int Id { get; private set; }
    public int Time { get; private set; }
    public Tweet Next { get; set; }
    public Tweet(int id, int time)
    {
        Id = id;
        Time = time;
    }
}

public class User
{
    public int Id { get; private set; }
    public HashSet<int> FolloweeIdSet { get; private set; }
    public LinkedList<Tweet> TweetList { get; private set; }
    public User(int id)
    {
        Id = id;
        FolloweeIdSet = new HashSet<int>();
        TweetList = new LinkedList<Tweet>();
    }

    public void PostTweet(int tweetId, int time)
    {
        var tweet = new Tweet(tweetId, time);
        if (TweetList.Count != 0)
        {
            tweet.Next = TweetList.First.Value;
        }
        TweetList.AddFirst(tweet);
    }

    public void Follow(int userId)
    {
        FolloweeIdSet.Add(userId);
    }

    public void Unfollow(int userId)
    {
        FolloweeIdSet.Remove(userId);
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
s.PostTweet(1, 1);
s.GetNewsFeed(1);
s.Follow(2, 1);
s.GetNewsFeed(2);
s.Unfollow(2, 1);
s.GetNewsFeed(2);
