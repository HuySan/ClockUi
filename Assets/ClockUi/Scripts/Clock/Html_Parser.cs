using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Web;
using UnityEngine;
using System.Net;

class Html_Parser
{
    private string _url = "https://time100.ru/";

    private HtmlDocument _htmlDocument = new HtmlDocument();
    WebClient _client = new WebClient();

    private string _time;

    private int _updateEveryHour = DateTime.Now.Hour - 1;//Смещение на 1 час, чтобы при старте вызывался метод парсинга

    public TimeSpan GetTime()
    {
        if (DateTime.Now.Hour > _updateEveryHour)
        {
            _updateEveryHour = DateTime.Now.Hour;

            if(!Parse())
                return DateTime.Now.TimeOfDay;

            return TimeSpan.Parse(_time);
        }

        return  DateTime.Now.TimeOfDay;
    }

    private bool Parse()
    {
        string html = _client.DownloadString(_url);
        _htmlDocument.LoadHtml(html);

        HtmlNode node = _htmlDocument.DocumentNode.SelectNodes("//*[@class='display-time monospace']").Where(x => x.InnerHtml.Contains("time")).FirstOrDefault();

        if (node == null)
            return false;

        string strNode = node.InnerHtml.ToString();
        _time = strNode.Substring(strNode.Count() - 12, 5);
        return true;
    }

}
