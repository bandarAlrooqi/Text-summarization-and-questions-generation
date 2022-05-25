using System;
using System.Web.UI;
using System.Net.Http;
using System.Collections.Generic;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace TSAQG
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void clear()
        {
hr.InnerHtml = "";
            questions.InnerHtml = "";
        }
        protected void processB_Click(object sender, EventArgs e)
        {
            clear();
             if(orignalT.Text.Split(' ').Length < 200)
            {
                hr.InnerHtml = "<div class='alert alert-danger' role='alert'>Orignal text must be 200 token or more.</div>";
            }
            else
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.Timeout = TimeSpan.FromHours(1);
                    client.BaseAddress = new Uri("https://tsaqg-dvtu5xlzta-el.a.run.app/");
                    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "run");
                    requestMessage.Content = JsonContent.Create(new { text = orignalT.Text });
                    var sent = client.SendAsync(requestMessage);

                    if (sent.Result.IsSuccessStatusCode)
                    {
                        var result = sent.Result.Content.ReadAsAsync<Data>();
                        var list = result.Result.result;

                        for (int i = 0; i < list.Count - 1; i += 2)
                        {
                            questions.InnerHtml +=

                                "<div><div class='input-group mb-3'>" +
                                    "<span class='input-group-text' id='" + i + "'>❔</span>" +
                                    "<input type='text' class='form-control' aria-describedby='" + i + "' value='" + list[i] + "' disabled>" +
                                "</div>";
                            questions.InnerHtml +=
                                    "<div class='input-group mb-3'>" +
                                          "<span class='input-group-text' id='" + (i + 1) + "'>❕</span>" +
                                          "<input type='text' class='form-control' aria-describedby='" + (i + 1) + "' value='" + list[i + 1] + "' disabled>" +
                                    "</div></div>";
                        }
                        summaryT.Text = list[list.Count - 1];
                    }
                    else
                    {
                        hr.InnerHtml = "<div class='alert alert-danger' role='alert'>Sorry something went wrong from our side.</div>";
                    }
                }catch(Exception err)
                {
                    hr.InnerHtml = "<div class='alert alert-danger' role='alert'>Sorry something went wrong from our side.</div>";
                }
            }
        }
    }
    struct Data
    {
        public List<string> result { get; set; }
    }
}