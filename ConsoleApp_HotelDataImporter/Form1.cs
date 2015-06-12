using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace ConsoleApp_HotelDataImporter
{
   public class Form1 : Form
   {
      HotelDataImporter importer;
      int oldcount;
      int count;
      int seconds;
      private Button button3;
      private ProgressBar progressBar1;
      System.Threading.Timer counttimer;
      public Form1()
      {
         InitializeComponent();
         importer = new HotelDataImporter();
         if (checkBox1.Checked)
         {
            importer.Action = postmsg;
            importer.Action3 = reportmsg;
         }
         if (checkBox2.Checked)
         {
            importer.Action2 = postmsg2;
         }
      }
      void timershow(object state)
      {
         string s = (count - oldcount).ToString();
         string s2 = (++seconds) + "秒";
         p(() =>
         {
            labelSpeed.Text = s;
            labelTotalTime.Text = s2;
            oldcount = count;
         });
      }
      void InitAnaly()
      {
         oldcount = 0;
         count = 0;
         seconds = 0;
         labelTotalTime.Text = "00:00:00";
         if (counttimer == null)
         {
            counttimer = new System.Threading.Timer(timershow, null, 0, 1000);
         }
      }
      void stopAnaly()
      {
         oldcount = 0;
         count = 0;
         if (counttimer != null)
         {
            counttimer.Change(Timeout.Infinite, Timeout.Infinite);
            counttimer.Dispose();
            counttimer = null;
            labelSpeed.Text = "0";
         }
         progressBar1.Value = 0;
      }
      void postmsg(object state)
      {
         //if (checkBox1.Checked)
         //{
         //   p(() =>
         //   {
         //      listBox1.Items.Add(state.ToString());
         //   });
         //}
         if (checkBox2.Checked)
         {
            count++;
            if (counttimer == null)
            {
               counttimer = new System.Threading.Timer(timershow, null, 0, 1000);
            }
         }
      }
      void postmsg2(object state)
      {
         if (checkBox1.Checked)
         {
            p(() =>
            {
               listBox1.Items.Add(state.ToString());
               listBox1.SelectedIndex = listBox1.Items.Count - 1;
            });
         }
      }

      void reportmsg(int percent)
      {
         if (checkBox1.Checked)
         {
            p(() =>
            {
               progressBar1.Value = percent;
               if (percent == 100)
               {
                  progressBar1.Value = 0;
               }
            });
         }
      }

      static void Main()
      {
         AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
         Application.Run(new Form1());
      }

      static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
      {
         HotelDataImporter.log((e.ExceptionObject as Exception).ToString());
      }

      private void button1_Click(object sender, EventArgs e)
      {
         InitAnaly();
         exec(importer.AddOrUpdateHotel);
      }

      private void button2_Click(object sender, EventArgs e)
      {
         InitAnaly();
         exec(importer.AddOrUpdateRoomTypeAndRoomRate);
      }


      void exec(Func<bool> act)
      {
         listBox1.Items.Clear();
         setEnabled(false);
         Thread t = new Thread(new ThreadStart(() =>
         {
            bool success = act();
            stopAnaly();
            s(() => { setEnabled(true); });
            finalResult(success);
         }));
         t.IsBackground = true;
         t.Start();
      }

      void setEnabled(bool s)
      {
         foreach (Control item in this.Controls)
         {
            if (item.Tag == null)
            {
               item.Enabled = s;
            }
         }
      }

      void p(MethodInvoker i)
      {
         this.BeginInvoke(i);
      }
      void s(MethodInvoker i)
      {
         this.Invoke(i);
      }

      void finalResult(bool success)
      {

         if (!success)
         {
            MessageBox.Show("运行过程中有错误，详情请参见日志文件");
         }
         else
         {
            MessageBox.Show("运行成功");
         }
      }

      private void button7_Click(object sender, EventArgs e)
      {
         if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "errorlog"))
         {
            Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory + "errorlog");
         }
         else
         {
            MessageBox.Show("目前没有错误日志");
         }
      }

      private void button8_Click(object sender, EventArgs e)
      {
         if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "sqlog"))
         {
            Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory + "sqlog");
         }
         else
         {
            MessageBox.Show("目前没有sql日志");
         }
      }
      #region ds
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.ListBox listBox1;
      private System.Windows.Forms.Button button7;
      private System.Windows.Forms.Button button8;
      private System.Windows.Forms.CheckBox checkBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label labelSpeed;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.CheckBox checkBox2;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label labelTotalTime;
      private System.ComponentModel.IContainer components = null;
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }
      private void InitializeComponent()
      {
          this.button1 = new System.Windows.Forms.Button();
          this.button2 = new System.Windows.Forms.Button();
          this.listBox1 = new System.Windows.Forms.ListBox();
          this.button7 = new System.Windows.Forms.Button();
          this.button8 = new System.Windows.Forms.Button();
          this.checkBox1 = new System.Windows.Forms.CheckBox();
          this.label1 = new System.Windows.Forms.Label();
          this.labelSpeed = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.checkBox2 = new System.Windows.Forms.CheckBox();
          this.label6 = new System.Windows.Forms.Label();
          this.labelTotalTime = new System.Windows.Forms.Label();
          this.button3 = new System.Windows.Forms.Button();
          this.progressBar1 = new System.Windows.Forms.ProgressBar();
          this.SuspendLayout();
          // 
          // button1
          // 
          this.button1.Location = new System.Drawing.Point(55, 12);
          this.button1.Name = "button1";
          this.button1.Size = new System.Drawing.Size(75, 34);
          this.button1.TabIndex = 0;
          this.button1.Text = "更新酒店";
          this.button1.UseVisualStyleBackColor = true;
          this.button1.Click += new System.EventHandler(this.button1_Click);
          // 
          // button2
          // 
          this.button2.Location = new System.Drawing.Point(166, 12);
          this.button2.Name = "button2";
          this.button2.Size = new System.Drawing.Size(89, 34);
          this.button2.TabIndex = 0;
          this.button2.Text = "更新房型房价";
          this.button2.UseVisualStyleBackColor = true;
          this.button2.Click += new System.EventHandler(this.button2_Click);
          // 
          // listBox1
          // 
          this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.listBox1.FormattingEnabled = true;
          this.listBox1.HorizontalScrollbar = true;
          this.listBox1.ItemHeight = 12;
          this.listBox1.Location = new System.Drawing.Point(0, 126);
          this.listBox1.Name = "listBox1";
          this.listBox1.Size = new System.Drawing.Size(678, 244);
          this.listBox1.TabIndex = 1;
          this.listBox1.Tag = "1";
          // 
          // button7
          // 
          this.button7.Location = new System.Drawing.Point(213, 52);
          this.button7.Name = "button7";
          this.button7.Size = new System.Drawing.Size(129, 34);
          this.button7.TabIndex = 0;
          this.button7.Tag = "1";
          this.button7.Text = "打开异常日志目录";
          this.button7.UseVisualStyleBackColor = true;
          this.button7.Click += new System.EventHandler(this.button7_Click);
          // 
          // button8
          // 
          this.button8.Location = new System.Drawing.Point(55, 52);
          this.button8.Name = "button8";
          this.button8.Size = new System.Drawing.Size(129, 34);
          this.button8.TabIndex = 0;
          this.button8.Tag = "1";
          this.button8.Text = "打开sql日志目录";
          this.button8.UseVisualStyleBackColor = true;
          this.button8.Click += new System.EventHandler(this.button8_Click);
          // 
          // checkBox1
          // 
          this.checkBox1.AutoSize = true;
          this.checkBox1.Checked = true;
          this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
          this.checkBox1.Location = new System.Drawing.Point(12, 104);
          this.checkBox1.Name = "checkBox1";
          this.checkBox1.Size = new System.Drawing.Size(72, 16);
          this.checkBox1.TabIndex = 2;
          this.checkBox1.Tag = "1";
          this.checkBox1.Text = "报告进度";
          this.checkBox1.UseVisualStyleBackColor = true;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(503, 108);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(65, 12);
          this.label1.TabIndex = 3;
          this.label1.Tag = "1";
          this.label1.Text = "处理速度：";
          // 
          // labelSpeed
          // 
          this.labelSpeed.ForeColor = System.Drawing.Color.Red;
          this.labelSpeed.Location = new System.Drawing.Point(569, 106);
          this.labelSpeed.Name = "labelSpeed";
          this.labelSpeed.Size = new System.Drawing.Size(46, 15);
          this.labelSpeed.TabIndex = 4;
          this.labelSpeed.Tag = "1";
          this.labelSpeed.Text = "0";
          this.labelSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.ForeColor = System.Drawing.Color.Black;
          this.label3.Location = new System.Drawing.Point(623, 107);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(23, 12);
          this.label3.TabIndex = 4;
          this.label3.Tag = "1";
          this.label3.Text = "/秒";
          // 
          // checkBox2
          // 
          this.checkBox2.AutoSize = true;
          this.checkBox2.Checked = true;
          this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
          this.checkBox2.Location = new System.Drawing.Point(422, 95);
          this.checkBox2.Name = "checkBox2";
          this.checkBox2.Size = new System.Drawing.Size(72, 16);
          this.checkBox2.TabIndex = 2;
          this.checkBox2.Tag = "1";
          this.checkBox2.Text = "测试计速";
          this.checkBox2.UseVisualStyleBackColor = true;
          // 
          // label6
          // 
          this.label6.AutoSize = true;
          this.label6.Location = new System.Drawing.Point(503, 83);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(65, 12);
          this.label6.TabIndex = 3;
          this.label6.Tag = "1";
          this.label6.Text = "总 耗 费：";
          // 
          // labelTotalTime
          // 
          this.labelTotalTime.ForeColor = System.Drawing.Color.Red;
          this.labelTotalTime.Location = new System.Drawing.Point(563, 81);
          this.labelTotalTime.Name = "labelTotalTime";
          this.labelTotalTime.Size = new System.Drawing.Size(91, 15);
          this.labelTotalTime.TabIndex = 4;
          this.labelTotalTime.Tag = "1";
          this.labelTotalTime.Text = "   ";
          this.labelTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // button3
          // 
          this.button3.Location = new System.Drawing.Point(290, 12);
          this.button3.Name = "button3";
          this.button3.Size = new System.Drawing.Size(89, 34);
          this.button3.TabIndex = 0;
          this.button3.Text = "清理过期房价";
          this.button3.UseVisualStyleBackColor = true;
          this.button3.Click += new System.EventHandler(this.button3_Click);
          // 
          // progressBar1
          // 
          this.progressBar1.Location = new System.Drawing.Point(90, 100);
          this.progressBar1.Name = "progressBar1";
          this.progressBar1.Size = new System.Drawing.Size(242, 23);
          this.progressBar1.TabIndex = 5;
          // 
          // Form1
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(678, 370);
          this.Controls.Add(this.progressBar1);
          this.Controls.Add(this.label3);
          this.Controls.Add(this.labelTotalTime);
          this.Controls.Add(this.labelSpeed);
          this.Controls.Add(this.label6);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.checkBox2);
          this.Controls.Add(this.checkBox1);
          this.Controls.Add(this.listBox1);
          this.Controls.Add(this.button8);
          this.Controls.Add(this.button7);
          this.Controls.Add(this.button3);
          this.Controls.Add(this.button2);
          this.Controls.Add(this.button1);
          this.Name = "Form1";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Tag = "1";
          this.Text = "Form1";
          this.Load += new System.EventHandler(this.Form1_Load);
          this.ResumeLayout(false);
          this.PerformLayout();

      }
      #endregion

      private void button3_Click(object sender, EventArgs e)
      {
         exec(importer.ClearExpiredRoomRate);
      }

      private void Form1_Load(object sender, EventArgs e)
      {
          InitAnaly();
          exec(importer.AddOrUpdateRoomTypeAndRoomRate);
      }
   }
}
