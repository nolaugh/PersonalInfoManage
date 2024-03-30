namespace PersonalInfoManage
{
    partial class Form_Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uiSmoothLabel1 = new Sunny.UI.UISmoothLabel();
            this.uiMarkLabel1 = new Sunny.UI.UIMarkLabel();
            this.uiMarkLabel2 = new Sunny.UI.UIMarkLabel();
            this.txt_Name = new Sunny.UI.UITextBox();
            this.txt_Pass = new Sunny.UI.UITextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_Cancel = new Sunny.UI.UIButton();
            this.btn_Login = new Sunny.UI.UIButton();
            this.uiMarkLabel3 = new Sunny.UI.UIMarkLabel();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.txt_PassTwice = new Sunny.UI.UITextBox();
            this.lbl_PassTwice = new Sunny.UI.UISmoothLabel();
            this.uiLedLabel1 = new Sunny.UI.UILedLabel();
            this.uiLedLabel2 = new Sunny.UI.UILedLabel();
            this.uiWaitingBar1 = new Sunny.UI.UIWaitingBar();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // uiSmoothLabel1
            // 
            this.uiSmoothLabel1.Font = new System.Drawing.Font("宋体", 16F);
            this.uiSmoothLabel1.Location = new System.Drawing.Point(204, 27);
            this.uiSmoothLabel1.Name = "uiSmoothLabel1";
            this.uiSmoothLabel1.Size = new System.Drawing.Size(342, 33);
            this.uiSmoothLabel1.TabIndex = 1;
            this.uiSmoothLabel1.Text = "欢迎进入个人信息管理系统！";
            // 
            // uiMarkLabel1
            // 
            this.uiMarkLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiMarkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiMarkLabel1.Location = new System.Drawing.Point(102, 137);
            this.uiMarkLabel1.Name = "uiMarkLabel1";
            this.uiMarkLabel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiMarkLabel1.TabIndex = 2;
            this.uiMarkLabel1.Text = "用户名：";
            this.uiMarkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiMarkLabel2
            // 
            this.uiMarkLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiMarkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiMarkLabel2.Location = new System.Drawing.Point(102, 211);
            this.uiMarkLabel2.Name = "uiMarkLabel2";
            this.uiMarkLabel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiMarkLabel2.TabIndex = 3;
            this.uiMarkLabel2.Text = "密码：";
            this.uiMarkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_Name
            // 
            this.txt_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Name.Location = new System.Drawing.Point(209, 131);
            this.txt_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Name.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Name.ShowText = false;
            this.txt_Name.Size = new System.Drawing.Size(355, 29);
            this.txt_Name.TabIndex = 4;
            this.txt_Name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Name.Watermark = "";
            // 
            // txt_Pass
            // 
            this.txt_Pass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Pass.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Pass.Location = new System.Drawing.Point(209, 205);
            this.txt_Pass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Pass.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Pass.Name = "txt_Pass";
            this.txt_Pass.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Pass.ShowText = false;
            this.txt_Pass.Size = new System.Drawing.Size(355, 29);
            this.txt_Pass.TabIndex = 5;
            this.txt_Pass.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Pass.Watermark = "";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.FillColor = System.Drawing.Color.Red;
            this.btn_Cancel.FillColor2 = System.Drawing.Color.Red;
            this.btn_Cancel.FillHoverColor = System.Drawing.Color.Red;
            this.btn_Cancel.FillPressColor = System.Drawing.Color.Red;
            this.btn_Cancel.FillSelectedColor = System.Drawing.Color.Red;
            this.btn_Cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Location = new System.Drawing.Point(447, 339);
            this.btn_Cancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.RectColor = System.Drawing.Color.Red;
            this.btn_Cancel.Size = new System.Drawing.Size(100, 35);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Login
            // 
            this.btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Login.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.Location = new System.Drawing.Point(130, 339);
            this.btn_Login.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(100, 35);
            this.btn_Login.TabIndex = 10;
            this.btn_Login.Text = "登录";
            this.btn_Login.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // uiMarkLabel3
            // 
            this.uiMarkLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiMarkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiMarkLabel3.Location = new System.Drawing.Point(102, 280);
            this.uiMarkLabel3.Name = "uiMarkLabel3";
            this.uiMarkLabel3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel3.Size = new System.Drawing.Size(160, 23);
            this.uiMarkLabel3.TabIndex = 11;
            this.uiMarkLabel3.Text = "验证码：";
            this.uiMarkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txt_PassTwice
            // 
            this.txt_PassTwice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_PassTwice.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PassTwice.Location = new System.Drawing.Point(209, 274);
            this.txt_PassTwice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_PassTwice.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_PassTwice.Name = "txt_PassTwice";
            this.txt_PassTwice.Padding = new System.Windows.Forms.Padding(5);
            this.txt_PassTwice.ShowText = false;
            this.txt_PassTwice.Size = new System.Drawing.Size(303, 29);
            this.txt_PassTwice.TabIndex = 6;
            this.txt_PassTwice.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_PassTwice.Watermark = "";
            // 
            // lbl_PassTwice
            // 
            this.lbl_PassTwice.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_PassTwice.Location = new System.Drawing.Point(519, 278);
            this.lbl_PassTwice.Name = "lbl_PassTwice";
            this.lbl_PassTwice.Size = new System.Drawing.Size(45, 25);
            this.lbl_PassTwice.TabIndex = 13;
            this.lbl_PassTwice.Text = "1234";
            // 
            // uiLedLabel1
            // 
            this.uiLedLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLedLabel1.Location = new System.Drawing.Point(625, 125);
            this.uiLedLabel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLedLabel1.Name = "uiLedLabel1";
            this.uiLedLabel1.Size = new System.Drawing.Size(127, 35);
            this.uiLedLabel1.TabIndex = 14;
            this.uiLedLabel1.Text = "bear";
            // 
            // uiLedLabel2
            // 
            this.uiLedLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLedLabel2.Location = new System.Drawing.Point(616, 199);
            this.uiLedLabel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLedLabel2.Name = "uiLedLabel2";
            this.uiLedLabel2.Size = new System.Drawing.Size(149, 35);
            this.uiLedLabel2.TabIndex = 15;
            this.uiLedLabel2.Text = "123456";
            // 
            // uiWaitingBar1
            // 
            this.uiWaitingBar1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiWaitingBar1.Location = new System.Drawing.Point(106, 399);
            this.uiWaitingBar1.MinimumSize = new System.Drawing.Size(70, 23);
            this.uiWaitingBar1.Name = "uiWaitingBar1";
            this.uiWaitingBar1.Size = new System.Drawing.Size(458, 29);
            this.uiWaitingBar1.TabIndex = 16;
            this.uiWaitingBar1.Text = "uiWaitingBar1";
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(804, 450);
            this.Controls.Add(this.uiWaitingBar1);
            this.Controls.Add(this.uiLedLabel2);
            this.Controls.Add(this.uiLedLabel1);
            this.Controls.Add(this.lbl_PassTwice);
            this.Controls.Add(this.txt_PassTwice);
            this.Controls.Add(this.uiMarkLabel3);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.txt_Pass);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.uiMarkLabel2);
            this.Controls.Add(this.uiMarkLabel1);
            this.Controls.Add(this.uiSmoothLabel1);
            this.DoubleBuffered = true;
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个人信息管理系统";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Sunny.UI.UISmoothLabel uiSmoothLabel1;
        private Sunny.UI.UIMarkLabel uiMarkLabel1;
        private Sunny.UI.UIMarkLabel uiMarkLabel2;
        private Sunny.UI.UITextBox txt_Name;
        private Sunny.UI.UITextBox txt_Pass;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private Sunny.UI.UIButton btn_Cancel;
        private Sunny.UI.UIButton btn_Login;
        private Sunny.UI.UIMarkLabel uiMarkLabel3;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private Sunny.UI.UITextBox txt_PassTwice;
        private Sunny.UI.UISmoothLabel lbl_PassTwice;
        private Sunny.UI.UILedLabel uiLedLabel1;
        private Sunny.UI.UILedLabel uiLedLabel2;
        private Sunny.UI.UIWaitingBar uiWaitingBar1;
    }
}

