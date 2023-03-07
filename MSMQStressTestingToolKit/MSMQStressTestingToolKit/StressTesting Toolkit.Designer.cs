namespace MSMQStressTestingToolKit
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbxSetting = new System.Windows.Forms.GroupBox();
            this.btnTextPackage = new System.Windows.Forms.Button();
            this.btnTextAmount = new System.Windows.Forms.Button();
            this.btnMessageQueueAmount = new System.Windows.Forms.Button();
            this.comTextPackage = new System.Windows.Forms.ComboBox();
            this.lblTextPackage = new System.Windows.Forms.Label();
            this.lblTestingAmt = new System.Windows.Forms.Label();
            this.lblMQAmt = new System.Windows.Forms.Label();
            this.comTextAmount = new System.Windows.Forms.ComboBox();
            this.comMessageQueueAmount = new System.Windows.Forms.ComboBox();
            this.gbxAction = new System.Windows.Forms.GroupBox();
            this.btnManualDeleteMessageQueueAndDict = new System.Windows.Forms.Button();
            this.btnCompletedTest = new System.Windows.Forms.Button();
            this.btnTimeGapTest = new System.Windows.Forms.Button();
            this.btnGenerateMessageQueue = new System.Windows.Forms.Button();
            this.btnBrutalTest = new System.Windows.Forms.Button();
            this.btnClearMessageQueue = new System.Windows.Forms.Button();
            this.btnClearSetting = new System.Windows.Forms.Button();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.gbxDashboard = new System.Windows.Forms.GroupBox();
            this.lblCpuLabel = new System.Windows.Forms.Label();
            this.txtDisplay = new System.Windows.Forms.GroupBox();
            this.display = new System.Windows.Forms.RichTextBox();
            this.lblCpuNum = new System.Windows.Forms.Label();
            this.lblCpuPercent = new System.Windows.Forms.Label();
            this.lblRamMB = new System.Windows.Forms.Label();
            this.lblRamNum = new System.Windows.Forms.Label();
            this.lblRamLabel = new System.Windows.Forms.Label();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.gbxSetting.SuspendLayout();
            this.gbxAction.SuspendLayout();
            this.gbxDashboard.SuspendLayout();
            this.txtDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxSetting
            // 
            this.gbxSetting.Controls.Add(this.btnTextPackage);
            this.gbxSetting.Controls.Add(this.btnTextAmount);
            this.gbxSetting.Controls.Add(this.btnMessageQueueAmount);
            this.gbxSetting.Controls.Add(this.comTextPackage);
            this.gbxSetting.Controls.Add(this.lblTextPackage);
            this.gbxSetting.Controls.Add(this.lblTestingAmt);
            this.gbxSetting.Controls.Add(this.lblMQAmt);
            this.gbxSetting.Controls.Add(this.comTextAmount);
            this.gbxSetting.Controls.Add(this.comMessageQueueAmount);
            this.gbxSetting.Location = new System.Drawing.Point(12, 12);
            this.gbxSetting.Name = "gbxSetting";
            this.gbxSetting.Size = new System.Drawing.Size(413, 267);
            this.gbxSetting.TabIndex = 0;
            this.gbxSetting.TabStop = false;
            this.gbxSetting.Text = "Setting";
            // 
            // btnTextPackage
            // 
            this.btnTextPackage.Location = new System.Drawing.Point(372, 120);
            this.btnTextPackage.Name = "btnTextPackage";
            this.btnTextPackage.Size = new System.Drawing.Size(35, 27);
            this.btnTextPackage.TabIndex = 8;
            this.btnTextPackage.Text = "?";
            this.btnTextPackage.UseVisualStyleBackColor = true;
            this.btnTextPackage.Click += new System.EventHandler(this.btnTextPackage_Click);
            // 
            // btnTextAmount
            // 
            this.btnTextAmount.Location = new System.Drawing.Point(372, 73);
            this.btnTextAmount.Name = "btnTextAmount";
            this.btnTextAmount.Size = new System.Drawing.Size(35, 27);
            this.btnTextAmount.TabIndex = 7;
            this.btnTextAmount.Text = "?";
            this.btnTextAmount.UseVisualStyleBackColor = true;
            this.btnTextAmount.Click += new System.EventHandler(this.btnTextAmount_Click);
            // 
            // btnMessageQueueAmount
            // 
            this.btnMessageQueueAmount.Location = new System.Drawing.Point(372, 30);
            this.btnMessageQueueAmount.Name = "btnMessageQueueAmount";
            this.btnMessageQueueAmount.Size = new System.Drawing.Size(35, 27);
            this.btnMessageQueueAmount.TabIndex = 6;
            this.btnMessageQueueAmount.Text = "?";
            this.btnMessageQueueAmount.UseVisualStyleBackColor = true;
            this.btnMessageQueueAmount.Click += new System.EventHandler(this.btnMessageQueueAmount_Click);
            // 
            // comTextPackage
            // 
            this.comTextPackage.FormattingEnabled = true;
            this.comTextPackage.Items.AddRange(new object[] {
            "Common",
            "XML"});
            this.comTextPackage.Location = new System.Drawing.Point(245, 120);
            this.comTextPackage.Name = "comTextPackage";
            this.comTextPackage.Size = new System.Drawing.Size(121, 27);
            this.comTextPackage.TabIndex = 5;
            // 
            // lblTextPackage
            // 
            this.lblTextPackage.AutoSize = true;
            this.lblTextPackage.Location = new System.Drawing.Point(6, 129);
            this.lblTextPackage.Name = "lblTextPackage";
            this.lblTextPackage.Size = new System.Drawing.Size(99, 19);
            this.lblTextPackage.TabIndex = 4;
            this.lblTextPackage.Text = "Text Package";
            // 
            // lblTestingAmt
            // 
            this.lblTestingAmt.AutoSize = true;
            this.lblTestingAmt.Location = new System.Drawing.Point(6, 81);
            this.lblTestingAmt.Name = "lblTestingAmt";
            this.lblTestingAmt.Size = new System.Drawing.Size(97, 19);
            this.lblTestingAmt.TabIndex = 3;
            this.lblTestingAmt.Text = "Text Amount";
            // 
            // lblMQAmt
            // 
            this.lblMQAmt.AutoSize = true;
            this.lblMQAmt.Location = new System.Drawing.Point(6, 34);
            this.lblMQAmt.Name = "lblMQAmt";
            this.lblMQAmt.Size = new System.Drawing.Size(177, 19);
            this.lblMQAmt.TabIndex = 2;
            this.lblMQAmt.Text = "MessageQueue Amount";
            // 
            // comTextAmount
            // 
            this.comTextAmount.FormattingEnabled = true;
            this.comTextAmount.Items.AddRange(new object[] {
            "100",
            "10000"});
            this.comTextAmount.Location = new System.Drawing.Point(245, 73);
            this.comTextAmount.Name = "comTextAmount";
            this.comTextAmount.Size = new System.Drawing.Size(121, 27);
            this.comTextAmount.TabIndex = 1;
            // 
            // comMessageQueueAmount
            // 
            this.comMessageQueueAmount.FormattingEnabled = true;
            this.comMessageQueueAmount.Items.AddRange(new object[] {
            "10",
            "200"});
            this.comMessageQueueAmount.Location = new System.Drawing.Point(245, 31);
            this.comMessageQueueAmount.Name = "comMessageQueueAmount";
            this.comMessageQueueAmount.Size = new System.Drawing.Size(121, 27);
            this.comMessageQueueAmount.TabIndex = 0;
            // 
            // gbxAction
            // 
            this.gbxAction.Controls.Add(this.btnManualDeleteMessageQueueAndDict);
            this.gbxAction.Controls.Add(this.btnCompletedTest);
            this.gbxAction.Controls.Add(this.btnTimeGapTest);
            this.gbxAction.Controls.Add(this.btnGenerateMessageQueue);
            this.gbxAction.Controls.Add(this.btnBrutalTest);
            this.gbxAction.Controls.Add(this.btnClearMessageQueue);
            this.gbxAction.Controls.Add(this.btnClearSetting);
            this.gbxAction.Controls.Add(this.btnSaveSetting);
            this.gbxAction.Location = new System.Drawing.Point(12, 285);
            this.gbxAction.Name = "gbxAction";
            this.gbxAction.Size = new System.Drawing.Size(413, 267);
            this.gbxAction.TabIndex = 1;
            this.gbxAction.TabStop = false;
            this.gbxAction.Text = "Action";
            // 
            // btnManualDeleteMessageQueueAndDict
            // 
            this.btnManualDeleteMessageQueueAndDict.Location = new System.Drawing.Point(218, 204);
            this.btnManualDeleteMessageQueueAndDict.Name = "btnManualDeleteMessageQueueAndDict";
            this.btnManualDeleteMessageQueueAndDict.Size = new System.Drawing.Size(189, 34);
            this.btnManualDeleteMessageQueueAndDict.TabIndex = 8;
            this.btnManualDeleteMessageQueueAndDict.Text = "EXPLOSION";
            this.btnManualDeleteMessageQueueAndDict.UseVisualStyleBackColor = true;
            this.btnManualDeleteMessageQueueAndDict.Click += new System.EventHandler(this.btnManualDeleteMessageQueueAndDict_Click);
            // 
            // btnCompletedTest
            // 
            this.btnCompletedTest.Enabled = false;
            this.btnCompletedTest.Location = new System.Drawing.Point(218, 42);
            this.btnCompletedTest.Name = "btnCompletedTest";
            this.btnCompletedTest.Size = new System.Drawing.Size(189, 34);
            this.btnCompletedTest.TabIndex = 7;
            this.btnCompletedTest.Text = "Completed Test";
            this.btnCompletedTest.UseVisualStyleBackColor = true;
            // 
            // btnTimeGapTest
            // 
            this.btnTimeGapTest.Enabled = false;
            this.btnTimeGapTest.Location = new System.Drawing.Point(218, 95);
            this.btnTimeGapTest.Name = "btnTimeGapTest";
            this.btnTimeGapTest.Size = new System.Drawing.Size(189, 34);
            this.btnTimeGapTest.TabIndex = 6;
            this.btnTimeGapTest.Text = "TimeGap Test";
            this.btnTimeGapTest.UseVisualStyleBackColor = true;
            this.btnTimeGapTest.Click += new System.EventHandler(this.btnTimeGapTest_Click);
            // 
            // btnGenerateMessageQueue
            // 
            this.btnGenerateMessageQueue.Enabled = false;
            this.btnGenerateMessageQueue.Location = new System.Drawing.Point(6, 150);
            this.btnGenerateMessageQueue.Name = "btnGenerateMessageQueue";
            this.btnGenerateMessageQueue.Size = new System.Drawing.Size(189, 35);
            this.btnGenerateMessageQueue.TabIndex = 4;
            this.btnGenerateMessageQueue.Text = "Generate Queue";
            this.btnGenerateMessageQueue.UseVisualStyleBackColor = true;
            this.btnGenerateMessageQueue.Click += new System.EventHandler(this.btnGenerateMessageQueue_Click);
            // 
            // btnBrutalTest
            // 
            this.btnBrutalTest.Enabled = false;
            this.btnBrutalTest.Location = new System.Drawing.Point(218, 150);
            this.btnBrutalTest.Name = "btnBrutalTest";
            this.btnBrutalTest.Size = new System.Drawing.Size(189, 34);
            this.btnBrutalTest.TabIndex = 3;
            this.btnBrutalTest.Text = "Brutal Test";
            this.btnBrutalTest.UseVisualStyleBackColor = true;
            this.btnBrutalTest.Click += new System.EventHandler(this.btnBrutalTest_Click);
            // 
            // btnClearMessageQueue
            // 
            this.btnClearMessageQueue.Location = new System.Drawing.Point(6, 204);
            this.btnClearMessageQueue.Name = "btnClearMessageQueue";
            this.btnClearMessageQueue.Size = new System.Drawing.Size(189, 34);
            this.btnClearMessageQueue.TabIndex = 2;
            this.btnClearMessageQueue.Text = "Clear Message Queue";
            this.btnClearMessageQueue.UseVisualStyleBackColor = true;
            this.btnClearMessageQueue.Click += new System.EventHandler(this.btnClearMessageQueue_Click);
            // 
            // btnClearSetting
            // 
            this.btnClearSetting.Location = new System.Drawing.Point(6, 95);
            this.btnClearSetting.Name = "btnClearSetting";
            this.btnClearSetting.Size = new System.Drawing.Size(189, 34);
            this.btnClearSetting.TabIndex = 1;
            this.btnClearSetting.Text = "Clear Setting";
            this.btnClearSetting.UseVisualStyleBackColor = true;
            this.btnClearSetting.Click += new System.EventHandler(this.btnClearSetting_Click);
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(6, 42);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(189, 35);
            this.btnSaveSetting.TabIndex = 0;
            this.btnSaveSetting.Text = "Save Setting";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // gbxDashboard
            // 
            this.gbxDashboard.Controls.Add(this.lblRamMB);
            this.gbxDashboard.Controls.Add(this.lblRamNum);
            this.gbxDashboard.Controls.Add(this.lblRamLabel);
            this.gbxDashboard.Controls.Add(this.lblCpuPercent);
            this.gbxDashboard.Controls.Add(this.lblCpuNum);
            this.gbxDashboard.Controls.Add(this.lblCpuLabel);
            this.gbxDashboard.Location = new System.Drawing.Point(12, 558);
            this.gbxDashboard.Name = "gbxDashboard";
            this.gbxDashboard.Size = new System.Drawing.Size(1400, 77);
            this.gbxDashboard.TabIndex = 2;
            this.gbxDashboard.TabStop = false;
            this.gbxDashboard.Text = "DashBoard";
            // 
            // lblCpuLabel
            // 
            this.lblCpuLabel.AutoSize = true;
            this.lblCpuLabel.Location = new System.Drawing.Point(6, 37);
            this.lblCpuLabel.Name = "lblCpuLabel";
            this.lblCpuLabel.Size = new System.Drawing.Size(42, 19);
            this.lblCpuLabel.TabIndex = 0;
            this.lblCpuLabel.Text = "CPU:";
            // 
            // txtDisplay
            // 
            this.txtDisplay.Controls.Add(this.display);
            this.txtDisplay.Location = new System.Drawing.Point(431, 12);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(981, 540);
            this.txtDisplay.TabIndex = 3;
            this.txtDisplay.TabStop = false;
            this.txtDisplay.Text = "Console";
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(12, 19);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(969, 515);
            this.display.TabIndex = 0;
            this.display.Text = "";
            // 
            // lblCpuNum
            // 
            this.lblCpuNum.AutoSize = true;
            this.lblCpuNum.Location = new System.Drawing.Point(69, 37);
            this.lblCpuNum.Name = "lblCpuNum";
            this.lblCpuNum.Size = new System.Drawing.Size(18, 19);
            this.lblCpuNum.TabIndex = 1;
            this.lblCpuNum.Text = "0";
            // 
            // lblCpuPercent
            // 
            this.lblCpuPercent.AutoSize = true;
            this.lblCpuPercent.Location = new System.Drawing.Point(106, 37);
            this.lblCpuPercent.Name = "lblCpuPercent";
            this.lblCpuPercent.Size = new System.Drawing.Size(22, 19);
            this.lblCpuPercent.TabIndex = 2;
            this.lblCpuPercent.Text = "%";
            // 
            // lblRamMB
            // 
            this.lblRamMB.AutoSize = true;
            this.lblRamMB.Location = new System.Drawing.Point(241, 37);
            this.lblRamMB.Name = "lblRamMB";
            this.lblRamMB.Size = new System.Drawing.Size(32, 19);
            this.lblRamMB.TabIndex = 5;
            this.lblRamMB.Text = "MB";
            // 
            // lblRamNum
            // 
            this.lblRamNum.AutoSize = true;
            this.lblRamNum.Location = new System.Drawing.Point(204, 37);
            this.lblRamNum.Name = "lblRamNum";
            this.lblRamNum.Size = new System.Drawing.Size(18, 19);
            this.lblRamNum.TabIndex = 4;
            this.lblRamNum.Text = "0";
            // 
            // lblRamLabel
            // 
            this.lblRamLabel.AutoSize = true;
            this.lblRamLabel.Location = new System.Drawing.Point(141, 37);
            this.lblRamLabel.Name = "lblRamLabel";
            this.lblRamLabel.Size = new System.Drawing.Size(46, 19);
            this.lblRamLabel.TabIndex = 3;
            this.lblRamLabel.Text = "RAM:";
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 647);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.gbxDashboard);
            this.Controls.Add(this.gbxAction);
            this.Controls.Add(this.gbxSetting);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxSetting.ResumeLayout(false);
            this.gbxSetting.PerformLayout();
            this.gbxAction.ResumeLayout(false);
            this.gbxDashboard.ResumeLayout(false);
            this.gbxDashboard.PerformLayout();
            this.txtDisplay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSetting;
        private System.Windows.Forms.GroupBox gbxAction;
        private System.Windows.Forms.GroupBox gbxDashboard;
        private System.Windows.Forms.GroupBox txtDisplay;
        private System.Windows.Forms.RichTextBox display;
        private System.Windows.Forms.ComboBox comTextPackage;
        private System.Windows.Forms.Label lblTextPackage;
        private System.Windows.Forms.Label lblTestingAmt;
        private System.Windows.Forms.Label lblMQAmt;
        private System.Windows.Forms.ComboBox comTextAmount;
        private System.Windows.Forms.ComboBox comMessageQueueAmount;
        private System.Windows.Forms.Button btnBrutalTest;
        private System.Windows.Forms.Button btnClearMessageQueue;
        private System.Windows.Forms.Button btnClearSetting;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.Button btnGenerateMessageQueue;
        private System.Windows.Forms.Button btnTextPackage;
        private System.Windows.Forms.Button btnTextAmount;
        private System.Windows.Forms.Button btnMessageQueueAmount;
        private System.Windows.Forms.Button btnCompletedTest;
        private System.Windows.Forms.Button btnTimeGapTest;
        private System.Windows.Forms.Button btnManualDeleteMessageQueueAndDict;
        private System.Windows.Forms.Label lblCpuLabel;
        private System.Windows.Forms.Label lblCpuNum;
        private System.Windows.Forms.Label lblRamMB;
        private System.Windows.Forms.Label lblRamNum;
        private System.Windows.Forms.Label lblRamLabel;
        private System.Windows.Forms.Label lblCpuPercent;
        private System.Windows.Forms.Timer updateTimer;
    }
}

