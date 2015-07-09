using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace SimpleComputerRobot
{
    public partial class Form1 : Form
    {
        private int max = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //string pattern="<div id=\"desc\">(?<name>.*?)</div>";
            //string content = "12313<div id=\"desc\">"+@"123123</div>12313</div>";
            //Regex reg = new Regex(pattern);
            //var val = reg.Match(content).Groups["name"].Value;
            //tbResult.Text = val;
            //return;

            Work();


        }
        private void Work()
        {
            ThreadStart threadstart = W;

            Thread thread = new Thread(threadstart);
            thread.IsBackground = true;
            thread.Start();
        }
        private void W()
        {
            var path = @"c:\a_data_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
            var path2 = @"c:\a_err_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
            string url = "http://www.cbmexpo.com/?m=user&a=exhibitor_detail&id=";
            var from = int.Parse(tbFrom.Text.Trim());
            var to = int.Parse(tbTo.Text.Trim());
            if (from > to)
            {
                MessageBox.Show("from 不能大于 to");
                return;
            }
            for (var i = from; i <= to; i++)
            {
                var urlReq = url + i;
                try
                {
                    var r = i + ","+ DateTime.Now+"," + ComputerRobot.GetInfo(urlReq).TrimEnd(',') + "\r\n";
                    //tbResult.Text += r;
                    SetText(r);
                    File.AppendAllText(path, r);
                    if (i % 50 == 0)
                    {
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    File.AppendAllText(path2, urlReq + "," + ex.Message + "\r\n");
                }
            }
            MessageBox.Show("finished");
        }

        private void SetText(string text)
        {
            // InvokeRequired需要比较调用线程ID和创建线程ID
            // 如果它们不相同则返回true
            if (this.tbResult.InvokeRequired)
            {
                var d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.tbResult.Text += text;
            }
        }

        delegate void SetTextCallback(string text);
    }

    class ComputerRobot
    {
        private string url;
        static string pattern = "<div id=\"desc\">(?<name>.*?)</div>";
        static Regex reg = new Regex(pattern, RegexOptions.Singleline);
        public static string GetInfo(string url)
        {
            string html = DoReq(url);
            if (html.Contains("error:"))
            {
                throw new Exception(html);
            }
            
            var val = reg.Match(html).Groups["name"].Value;
            if (string.IsNullOrEmpty(val))
                return "";
            var lines = val.Split(new string[] { "\r\n" }, StringSplitOptions.None); ;
            var sb=new StringBuilder();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                var i = line.IndexOf('<');
                var newL = line;
                if (i != -1)
                {
                    newL = line.Substring(0, i);
                }
                newL = newL.Trim().Split('：')[1].Replace(',', '，');
                sb.Append(newL+",");
            }
            return sb.ToString();
        }

        public static string DoReq(string url)
        {
            HttpWebRequest webRequest = WebRequest.CreateHttp(url);
            webRequest.Timeout = 1000 * 10;
            
            StreamReader responseReader = null;
            string responseData = "";
            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch(Exception ex)
            {
                return "error:"+ex.Message;
            }
            finally
            {
                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }
            return responseData; 

            //WebClient wc=new WebClient();
        
            //wc.Encoding = Encoding.UTF8;
            //var html = wc.DownloadString(url);
            //wc.Dispose();
            //return html;
        }
    }
}
