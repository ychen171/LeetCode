public class Codec
{
    Dictionary<int, string> hashUrlDict = new Dictionary<int, string>();
    string tinyPrefix = "http://tinyurl.com/";
    // Encodes a URL to a shortened URL
    public string encode(string longUrl)
    {
        int hashCode = longUrl.GetHashCode();
        hashUrlDict[hashCode] = longUrl;
        return tinyPrefix + hashCode;
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl)
    {
        int hashCode = int.Parse(shortUrl.Replace(tinyPrefix, ""));
        return hashUrlDict[hashCode];
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));

public class UniqueCodec
{
    Dictionary<string, string> hashUrlDict = new Dictionary<string, string>();
    string tinyPrefix = "http://tinyurl.com/";
    // Encodes a URL to a shortened URL
    public string encode(string longUrl)
    {
        Guid guid = Guid.NewGuid();
        string hashStr = guid.ToString();
        hashUrlDict[hashStr] = longUrl;
        return tinyPrefix + hashStr;
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl)
    {
        string hashStr = shortUrl.Replace(tinyPrefix, "");
        return hashUrlDict[hashStr];
    }
}