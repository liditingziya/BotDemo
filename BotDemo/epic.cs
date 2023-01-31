using System.Net;

namespace BotDemo;

public static class epic
{
    private static readonly string epic_url =
        "https://store-site-backend-static-ipv4.ak.epicgames.com/freeGamesPromotions?locale=zh-CN&country=CN&allowCountries=CN";

    [Obsolete("Obsolete")]
    public static string? GetEpicGame()
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(epic_url);
        httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36";
        //获得Web服务器的响应
        try
        {
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //查看网页的响应，如果StatusCode!=200就返回null！
            if (httpWebResponse.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }
            //获得网页的返回流
            var htmlStream = httpWebResponse.GetResponseStream();
            var streamReader = new StreamReader(htmlStream);

            //读取流中的数据并转化为string
            var stringWebSource = streamReader.ReadToEnd();
            return stringWebSource;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return "";
    }


}