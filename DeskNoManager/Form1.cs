using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskNoManager
{
    public partial class Form1 : Form
    {
        readonly DeskNoLotter _lotter=new DeskNoLotter();
        private bool _isRunning;
        public Form1()
        {
            InitializeComponent();
            _lotter.InitData();
            ShowFreeCount();
        }

        private void ShowFreeCount()
        {
            lblFree.Text = "剩余 " + _lotter.GetFreeCount() + "个号码。";
        }

        delegate void SetTextCallback(Label lbl, string text);

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_isRunning)
                {
                    MessageBox.Show("请先停止号码滚动");
                    return;
                }
                _isRunning = true;
                lblNo1.Text = "000";
                timer1.Start();
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (!_isRunning)
                {
                    MessageBox.Show("请先开始号码滚动");
                    return;
                }
                _isRunning = false;
                timer1.Stop();
                _lotter.Confirm();
                ShowFreeCount();
            }
            base.OnKeyDown(e);
        }


        private void SetText(Label lbl, string text)
        {
            // InvokeRequired需要比较调用线程ID和创建线程ID
            // 如果它们不相同则返回true
            if (lbl.InvokeRequired)
            {
                var d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] {lbl, text });
            }
            else
            {
                lbl.Text = text;
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            _lotter.Rock();
            if (_lotter.CurrDestNoInf == null)
            {
                timer1.Stop();
                MessageBox.Show("没有号码了");
                return;
            }
            SetText(lblNo1, _lotter.CurrDestNoInf.No);
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    class DestNoInf
    {
        public string No { get; set; }
        public bool IsUsed { get; set; }
    }

    class DeskNoLotter
    {

        private IList<DestNoInf> DeskNoList = new List<DestNoInf>();
        public DestNoInf CurrDestNoInf { get; private set; }
        private string _filePath = AppDomain.CurrentDomain.BaseDirectory +@"desk.txt";
        public void InitData()
        {
            if (!File.Exists(_filePath))
            {
                return;
            }
            string[] lines = File.ReadAllLines(_filePath);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                var arrData = line.Split(',');
                var isUse = false;
                isUse = arrData.Length >1 && arrData[1] == "1";
                var deskNoInfo = new DestNoInf() {No = arrData[0],IsUsed = isUse};
                DeskNoList.Add(deskNoInfo);
            }
        }

        public void Rock()
        {
            CurrDestNoInf = null;
            var deskNo = DeskNoList.Where(x => x.IsUsed == false).ToArray();
            if (deskNo.Length == 0)
            {
                return;
            }
            Random _r = new Random();
            CurrDestNoInf = deskNo[_r.Next(0, deskNo.Length)];
        }

        public void Confirm()
        {
            if (CurrDestNoInf != null)
            {
                CurrDestNoInf.IsUsed = true;
                Save();
            }
        }

        private void Save()
        {
            var sb=new StringBuilder();
            foreach (var destNoInf in DeskNoList)
            {
                sb.AppendLine(destNoInf.No + "," + (destNoInf.IsUsed ? "1" : "0"));
            }
            File.WriteAllText(_filePath,sb.ToString());
        }

        public int GetFreeCount()
        {
            return DeskNoList.Count(x => x.IsUsed==false);
        }
    }

}
