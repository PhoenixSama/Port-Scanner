using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace AppScan
{
	public partial class Form1 : Form
	{
		//开始ip
		private long IP_START;
		//结束ip
		private long IP_END;
		//最大线程
		private int MAX_THREAD;
		//现在运行
		private int THIS_THREAD = 0;
		//在线运行锁
		private object LOCK_THIS_THREAD = new object();
		//扫描端口
		private List<int> LIST_PORT = new List<int>();
		//是否运行
		private bool IsRun = true;
		//锁
		private object LOCK_OBJ = new object();
		//ip
		private static String IP_PATH = AppDomain.CurrentDomain.BaseDirectory + "ip.txt";
		//定时清理
		private System.Timers.Timer timegc = null;
		//新行
		private readonly String NewLine;

		private int IPCOUNT = 0;

		private int IPTHIS = 0;

		private object LOCK_INT = new object();

		//判断执行完毕没有 0.5秒判断一次
		private System.Timers.Timer timesuccess = new System.Timers.Timer(500);

		//开始时间
		private DateTime DT_START;
		private DateTime DT_END;

		public Form1()
		{
			//System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
			//sw.Start();
			//Task.Factory.StartNew(() => RunIP(IntToIp(IP_START), item),TaskCreationOptions.PreferFairness);
			//sw.Stop();
			//Console.WriteLine("Thread总共花费{0}ms.", sw.Elapsed.TotalMilliseconds);
			NewLine = System.Environment.NewLine;
			InitializeComponent();
			timegc = new System.Timers.Timer(30000); //30秒执行清理一次
			timegc.Elapsed += new System.Timers.ElapsedEventHandler(Timer_TimesUp_1);
			timegc.Start();
			//执行完毕
			timesuccess.Elapsed += timesuccess_Elapsed;
		}

		private void timesuccess_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if (IPTHIS == IPCOUNT)
			{
				DT_END = DateTime.Now;
				//停止
				timesuccess.Stop();
				LIST_PORT.Clear();
				base.Invoke(new Action(() =>
				{
					btnstart.Text = "开始";
					txtstartip.Enabled = txtendip.Enabled = txtxiancheng.Enabled = txtprot.Enabled = true;
					TimeSpan tspan = (DT_END - DT_START);
					double dtdb = tspan.TotalSeconds;
					string sb = string.Format("{0}时:{1}分:{2}秒", tspan.Hours, tspan.Minutes, tspan.Seconds);
					//string dtdb1 = String.Format("{0}时:{1}分:{2:F}秒", tspan.TotalHours, tspan.TotalMinutes, dtdb);
					double dtchuli = IPCOUNT / dtdb;
					string str1 = String.Format("{0:F}", dtchuli);
					//默认为保留两位
					txtresult.AppendText(DateTime.Now.ToString("HH:mm:ss.fff") + "_全部扫描完成!" + NewLine);
					txtresult.AppendText(DateTime.Now.ToString("HH:mm:ss.fff") + "_共扫描:" + IPCOUNT + "次,共耗时:!" + sb + ",平均每秒扫描:" + str1 + "次" + NewLine);
				}));		
			}
		}

		private void Timer_TimesUp_1(object sender, System.Timers.ElapsedEventArgs e)
		{
			base.Invoke(new Action(() =>
			{
				if (txtresult.Lines.Count() > 500) { txtresult.Text = string.Empty; }
			}));
		}

		private void btnstart_Click(object sender, EventArgs e)
		{
			switch (btnstart.Text)
			{
				case "开始":
					AppStart();
					break;
				case "暂停":
					IsRun = false;
					timesuccess.Stop();
					btnstart.Text = "继续";
					break;
				case "继续":
					IsRun = true;
					timesuccess.Start();
					btnstart.Text = "暂停";
					break;
				default:
					break;
			}
		}

		private void AppStart()
		{
			string startIP = txtstartip.Text.Trim();
			string endIP = txtendip.Text.Trim();
			if (string.IsNullOrEmpty(startIP) || string.IsNullOrEmpty(endIP))
			{
				MessageBox.Show("IP地址不能为空！");
				return;
			}

			if (!IPCheck(startIP))
			{
				MessageBox.Show("开始地址错误！");
				txtstartip.Focus();
				return;
			}

			if (!IPCheck(endIP))
			{
				MessageBox.Show("结束地址错误");
				txtendip.Focus();
				return;
			}

			//获取前三段
			string sstartIP = startIP.Substring(0, startIP.LastIndexOf('.'));
			string sendIP = endIP.Substring(0, endIP.LastIndexOf('.'));
			if (!sstartIP.Substring(0, sstartIP.LastIndexOf('.') + 1).Equals(
				sendIP.Substring(0, sendIP.LastIndexOf('.') + 1)))
			{
				MessageBox.Show("IP地址前2位必须相同！");
				return;
			}
			IP_START = IpToInt(startIP);
			IP_END = IpToInt(endIP);
			//判断起始ip是否正确
			if (IP_END < IP_START)
			{
				MessageBox.Show("天啊，起始ip居然比终止ip还大");
				return;
			}
			if (!int.TryParse(txtxiancheng.Text.Trim(), out MAX_THREAD))
			{
				MessageBox.Show("最大线程填写错误!");
				txtxiancheng.Focus();
				return;
			}
			if (string.IsNullOrWhiteSpace(txtprot.Text))
			{
				MessageBox.Show("端口为空！");
				txtprot.Focus();
				return;
			}
			string[] port = txtprot.Text.Trim().Split(',');
			foreach (var item in port)
			{
				try
				{
					string[] portFiter = item.Split('-');
					switch (portFiter.Count())
					{
						case 1:
							LIST_PORT.Add(Convert.ToInt32(item));
							break;
						case 2:
							int i_start = Convert.ToInt32(portFiter[0]);
							int i_end = Convert.ToInt32(portFiter[1]);
							for (; i_start <= i_end; i_start++)
							{
								LIST_PORT.Add(i_start);
							}
							break;
						default:
							break;
					}
				}
				catch { }
			}
			LIST_PORT = LIST_PORT.Where(x => x > 0 && x <= 65536).ToList().Distinct().ToList();
			toolStripStatusLabel4.Text = "|本次扫描ip:" + (Convert.ToInt32(IP_END - IP_START) + 1) + "个";
			if (MessageBox.Show(string.Format("共扫描端口:{0}", LIST_PORT.Count), "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			//开始扫描,重新初始化
			IPCOUNT = (Convert.ToInt32(IP_END - IP_START) + 1) * LIST_PORT.Count;
			IPTHIS = 0;
			IsRun = true;
			txtresult.Text = string.Empty;
			THIS_THREAD = 0;
			progressip.Maximum = IPCOUNT;
			progressip.Value = 0;
			btnstart.Text = "暂停";
			txtstartip.Enabled = txtendip.Enabled = txtxiancheng.Enabled = txtprot.Enabled = false;
			timesuccess.Start();
			DT_START = DateTime.Now;
			new Thread(new ThreadStart(ScanIP)) { IsBackground = true }.Start();
		}

		private void ScanIP()
		{
			for (; IP_START <= IP_END; IP_START++)
			{
				foreach (var item in LIST_PORT)
				{
					//位false就暂停
					while (!IsRun) { Thread.Sleep(1000); }
					while (THIS_THREAD >= MAX_THREAD) { Thread.Sleep(1000); }
					//task 太慢了Task
					IPClass model = new IPClass()
					{
						myip = IntToIp(IP_START),
						myport = item
					};
					new Thread(() => RunIP(model)) { IsBackground = true }.Start();
				}
			}
		}


		private void RunIP(object obj)
		{
			lock (LOCK_THIS_THREAD)
			{
				THIS_THREAD++;
			}
			IPClass model = (IPClass)obj;
			try
			{
				using (TcpClient tc = new TcpClient())
				{
					//设置超时时间
					tc.SendTimeout = tc.ReceiveTimeout = 2000;
					//异步方法
					IAsyncResult oAsyncResult = tc.BeginConnect(model.myip, model.myport, null, null);
					oAsyncResult.AsyncWaitHandle.WaitOne(1000, true);//1000为超时时间 
					if (tc.Connected)
					{
						//ip端口开放
						lock (LOCK_OBJ)
						{
							try
							{
								System.IO.File.AppendAllText(IP_PATH, string.Format("{0}:{1}", model.myip, model.myport) + NewLine, Encoding.UTF8);
							}
							catch { }
						}
						base.Invoke(new Action(() =>
						{
							txtresult.AppendText(string.Format("IP:{0},端口:{1} 开放", model.myip, model.myport) + NewLine);
						}));
					}
				}

			}
			catch { }
			finally
			{
				model = null;
				obj = null;
				lock (LOCK_THIS_THREAD)
				{
					THIS_THREAD--;
				}
				lock (LOCK_INT)
				{
					IPTHIS++;
				}
				base.Invoke(new Action(() =>
				{
					progressip.Value++;
				}));
			}
		}


		/// <summary>
		/// 正规则试验IP地址
		/// </summary>
		/// <param name="IP"></param>
		/// <returns></returns>
		public bool IPCheck(string IP)
		{
			string num = "(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)";
			return Regex.IsMatch(IP, ("^" + num + "\\." + num + "\\." + num + "\\." + num + "$"));
		}

		#region ip转换
		/// <summary>
		/// ip转成long
		/// </summary>
		/// <param name="ip"></param>
		/// <returns></returns>
		public static long IpToInt(string ip)
		{
			char[] separator = new char[] { '.' };
			string[] items = ip.Split(separator);
			return long.Parse(items[0]) << 24
					| long.Parse(items[1]) << 16
					| long.Parse(items[2]) << 8
					| long.Parse(items[3]);
		}
		/// <summary>
		/// long转成ip
		/// </summary>
		/// <param name="ipInt"></param>
		/// <returns></returns>
		public static string IntToIp(long ipInt)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append((ipInt >> 24) & 0xFF).Append(".");
			sb.Append((ipInt >> 16) & 0xFF).Append(".");
			sb.Append((ipInt >> 8) & 0xFF).Append(".");
			sb.Append(ipInt & 0xFF);
			return sb.ToString();
		}
		#endregion

		private void txtprot_MouseEnter(object sender, EventArgs e)
		{
			this.toolTip1.ToolTipTitle = "端口";

			this.toolTip1.IsBalloon = false;

			this.toolTip1.UseFading = true;

			this.toolTip1.Show("可以设置单个端口或者扫描区间,例如:80,90-1000", this.txtprot);
		}

		private void txtprot_MouseLeave(object sender, EventArgs e)
		{
			this.toolTip1.Hide(txtprot);     //隐藏提示窗口
		}
	}

	public class IPClass
	{
		public string myip { get; set; }

		public int myport { get; set; }
	}
}
