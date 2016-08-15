using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Windows安装助手
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static bool efi;
        public static string ApplicationPath;
        public static bool finished = false;
        public bool RedirectStandardError { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            //通过bceedit检查系统是否通过uefi固件启动
            Process ifefi = new Process(); 
            ifefi.StartInfo.FileName = "cmd.exe";
            ifefi.StartInfo.Arguments = "/c bcdedit /enum {current}";
            ifefi.StartInfo.UseShellExecute = false;
            ifefi.StartInfo.RedirectStandardInput = true;
            ifefi.StartInfo.RedirectStandardOutput = true;
            ifefi.StartInfo.RedirectStandardError = true;
            ifefi.StartInfo.CreateNoWindow = true;
            ifefi.Start();
            string  efiresult = ifefi.StandardOutput.ReadToEnd().ToString();
            if(efiresult.Contains(@"\Windows\system32\winload.efi")) //判断bcdedit输出结果中是否含有“\Windows\system32\winload.efi”，如果有，系统就是通过uefi固件启动的，使用uefi模式。
            {
                //结果为uefi固件启动
                //
                //后期要加的东西，不要在意。(*^_^*)
                //MessageBox.Show("您的电脑使用的是EFI启动模式，某些功能可能不可用。","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                //
                efi = true;
                this.Text = "Windows安装助手 EFI模式";
            }
            else //结果为bios固件启动
            {
                efi = false;
                this.Text = "Windows安装助手 BIOS模式";
            }
            ApplicationPath = Application.StartupPath; //获取程序所在目录
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            textBox2.Text = saveFileDialog1.FileName;
            if (saveFileDialog1.FileName.Contains("C:\\")) //判断是否用户准备在当前系统盘防止安装文件，如果用户准备在系统盘防止安装文件，提示用户可能无法全新安装。
            {
                MessageBox.Show("注意：\n您选择了在系统盘内保存安装文件，您在安装过程中将无法格式化系统盘！\n如果您在用户文件夹或者系统文件夹内保存，安装到当前系统盘的安装将完全无法进行！\n如果你完全看不懂这段话，请换个位置保存！","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!finished) //判断是否完成，如果完成，按钮显示的时“重新启动计算机”，点击后程序将重启电脑
            {
                progressBar1.Value = 0; //重设processbar1进度
                if ((textBox1.Text == "请选择您要安装的系统镜像文件") || (textBox1.Text == "")) //判断用户是否选择了文件
                {
                    MessageBox.Show("您尚未选择您要安装的系统镜像文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if ((textBox2.Text == "请选择您安装文件的存放位置") || (textBox2.Text == "")) //判断用户是否选择了文件
                {
                    MessageBox.Show("您尚未选择您要安装的系统镜像文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if ((!System.IO.File.Exists(ApplicationPath + "/bin/x64/7z.exe")) || (!System.IO.File.Exists(ApplicationPath + "/bin/x64/7z.dll"))) //检查7z组件是否缺失
                {
                    MessageBox.Show("程序目录中缺少了某些必须文件，请重新下载程序或者把程序解压到一个目录里而不是直接在压缩软件里双击运行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    button3.Enabled = false;//禁用按钮控件，防止用户乱动
                    progressBar1.Value = 10; //进度条滚动一些，安慰用户
                    Directory.CreateDirectory(ApplicationPath + "/temp"); //创建临时文件夹
                                                                          //下面那几句：创建diskpart脚本文件
                    string[] DpShell = new string[] { @"Creat Vdisk File=""" + textBox2.Text + @""" Maximum=5000 Type=Expandable NOERR", @"Select Vdisk File=""" + textBox2.Text + @""" NOERR", "Attach Vdisk NOERR", "Creat Partition Primary", "Format FS=FAT32 Quick", "ASSIGN LETTER=Y", "Exit", "Exit", "Exit", "Exit", "Exit", "Exit", "Exit", "Exit", "Exit", "Exit", "Exit", "Exit", "Exit", "Exit", };
                    File.WriteAllLines(ApplicationPath + "/temp/cre.dp", DpShell);
                    //下面几句：创建创建启动项时的脚本
                    string Gudi = "{" + Guid.NewGuid().ToString() + "}";
                    string[] BcdShell;
                    if (efi) //efi与bios要区别对待
                    {
                        BcdShell = new string[] {  @"bcdedit /create " + Gudi + @" /d ""安装Windows"" /application osloader", @"bcdedit /set " + Gudi + @" device ramdisk =[Y:]\sources\boot.wim", @"bcdedit /set " + Gudi + @" path \windows\system32\winload.efi", @"bcdedit  /set " + Gudi + @" osdevice ramdisk=[Y:]\sources\boot.wim", @"bcdedit /set " + Gudi + @" systemroot \windows", @"bcdedit /set " + Gudi + @" winpe Yes", @"bcdedit /set " + Gudi + @" detecthal Yes", @"bcdedit /set " + Gudi + @" inherit {bootloadersettings}", @"bcdedit /set " + Gudi + @" locale zh-CN", @"bcdedit /set " + Gudi + @" ems Yes", @"bcdedit /displayorder " + Gudi + @" /addlast" };
                    }
                    else
                    {
                        BcdShell = new string[] {  @"bcdedit /create " + Gudi + @" /d ""安装Windows"" /application osloader", @"bcdedit  /set " + Gudi + @" device ramdisk =[Y:]\sources\boot.wim", @"bcdedit /set " + Gudi + @" path \windows\system32\winload.exe", @"bcdedit /set " + Gudi + @" osdevice ramdisk=[Y:]\sources\boot.wim", @"bcdedit /set " + Gudi + @" systemroot \windows", @"bcdedit /set " + Gudi + @" winpe Yes", @"bcdedit /set " + Gudi + @" detecthal Yes", @"bcdedit /set " + Gudi + @" inherit {bootloadersettings}", @"bcdedit /set " + Gudi + @" locale zh-CN", @"bcdedit /set " + Gudi + @" ems Yes", @"bcdedit /displayorder " + Gudi + @" /addlast" };
                    }
                    File.WriteAllLines(ApplicationPath + "/temp/newboot.cmd", BcdShell);
                    //运行创建虚拟磁盘的diskpart脚本
                    Process creatvdisk = new Process();
                    creatvdisk.StartInfo.FileName = "diskpart.exe";
                    creatvdisk.StartInfo.Arguments = @"/s """ + ApplicationPath + @"\temp\cre.dp""";
                    creatvdisk.StartInfo.UseShellExecute = false;
                    creatvdisk.StartInfo.RedirectStandardInput = true;
                    creatvdisk.StartInfo.RedirectStandardOutput = true;
                    creatvdisk.StartInfo.RedirectStandardError = true;
                    creatvdisk.StartInfo.CreateNoWindow = true;
                    creatvdisk.Start();
                    creatvdisk.WaitForExit();
                    progressBar1.Value = 20;
                    //进度条滚动一些，安慰用户
                    //处理虚拟硬盘结束
                    //以下：利用7-zip将ISO文件解压到虚拟磁盘里
                    Process unzip = new Process();
                    unzip.StartInfo.FileName = ApplicationPath + @"\bin\x64\7z.exe";
                    unzip.StartInfo.Arguments = @"x -y """ + openFileDialog1.FileName + @""" -oY:\";
                    unzip.StartInfo.UseShellExecute = false;
                    unzip.StartInfo.RedirectStandardInput = true;
                    unzip.StartInfo.RedirectStandardOutput = true;
                    unzip.StartInfo.RedirectStandardError = true;
                    unzip.StartInfo.CreateNoWindow = true;
                    unzip.Start();
                    unzip.WaitForExit();
                    progressBar1.Value = 80; //进度条滚动一些，安慰用户
                                             //解压结束
                                             //以下：添加启动项
                    Process bcd = new Process();
                    bcd.StartInfo.FileName = "cmd.exe";
                    bcd.StartInfo.Arguments = "/c " + ApplicationPath + @"\temp\newboot.cmd";
                    bcd.StartInfo.UseShellExecute = false;
                    bcd.StartInfo.RedirectStandardInput = true;
                    bcd.StartInfo.RedirectStandardOutput = true;
                    bcd.StartInfo.RedirectStandardError = true;
                    bcd.StartInfo.CreateNoWindow = true;
                    bcd.Start();
                    bcd.WaitForExit();
                    //添加启动项结束
                    progressBar1.Value = 100;
                    if (RedirectStandardError) //检索错误信息
                    {
                        MessageBox.Show("发现如下错误：" + creatvdisk.StandardError.ReadToEnd() + unzip.StandardError.ReadToEnd() + bcd.StandardError.ReadToEnd(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        progressBar1.Value = 0;
                    }
                    else
                    {
                        MessageBox.Show("操作成功完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    //清理临时目录    
                    Process cleandir = new Process();
                    cleandir.StartInfo.UseShellExecute = false;
                    cleandir.StartInfo.FileName = "cmd.exe";
                    cleandir.StartInfo.Arguments = @"/c del /f /q """ + ApplicationPath + @"\temp""";
                    cleandir.StartInfo.CreateNoWindow = true;
                    cleandir.Start();
                    cleandir.WaitForExit();
                    Directory.Delete(ApplicationPath + "/temp");
                    finished = true; //标记已处理完成
                    button3.Enabled = true;
                    button3.Text = "重新启动计算机";
                }
            }
            else
            {
                //重启电脑的参数
                Process restart = new Process();
                restart.StartInfo.UseShellExecute = false;
                restart.StartInfo.FileName = "shutdown.exe";
                restart.StartInfo.Arguments = @"/r /f /t 0";
                restart.Start();
            }
        }
    }
}
