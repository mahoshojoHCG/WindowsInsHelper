namespace Windows安装助手
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(594, 83);
            this.label1.TabIndex = 0;
            this.label1.Text = "Windows 安装助手";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("等线", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(26, 114);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(489, 29);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "请选择您要安装的系统镜像文件";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("等线", 15.75F);
            this.button1.Location = new System.Drawing.Point(521, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("等线", 13F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Windows镜像文件：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("等线", 13F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(23, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "安装文件存放位置：";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("等线", 15.75F);
            this.button2.Location = new System.Drawing.Point(521, 171);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 29);
            this.button2.TabIndex = 5;
            this.button2.Text = "浏览";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("等线", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(26, 171);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(489, 29);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "请选择您安装文件的存放位置";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Windows光盘镜像文件|*.iso";
            this.openFileDialog1.Title = "选择Windows光盘镜像文件";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "WIH.vhdx";
            this.saveFileDialog1.Filter = "Windows虚拟磁盘文件（Windows8及以上）|*.vhdx|Windows虚拟磁盘文件（Windows7）|*.vhd";
            this.saveFileDialog1.Title = "选择Windows安装文件存放位置";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(27, 217);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(579, 27);
            this.progressBar1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("等线", 15.75F);
            this.button3.Location = new System.Drawing.Point(521, 254);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 29);
            this.button3.TabIndex = 8;
            this.button3.Text = "执行";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(0)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(646, 295);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Windows安装助手";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button3;
    }
}

