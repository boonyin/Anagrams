namespace Anagrams
{
    partial class Configure
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioTimerNone = new System.Windows.Forms.RadioButton();
            this.textboxSecondsPerLetter = new System.Windows.Forms.TextBox();
            this.textboxTimerStatic = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioTimerBoth = new System.Windows.Forms.RadioButton();
            this.radioTimerPerLetter = new System.Windows.Forms.RadioButton();
            this.radioTimerStatic = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkboxAwardBonusTime = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxBonusWords = new System.Windows.Forms.TextBox();
            this.textboxBonusTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textboxLetterPool = new System.Windows.Forms.TextBox();
            this.radioLetterPoolStatic = new System.Windows.Forms.RadioButton();
            this.radioLetterPoolRandom = new System.Windows.Forms.RadioButton();
            this.checkboxAllowRepeats = new System.Windows.Forms.CheckBox();
            this.checkboxPlaySounds = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonDefaultSettings = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(54, 447);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(136, 447);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioTimerNone);
            this.groupBox4.Controls.Add(this.textboxSecondsPerLetter);
            this.groupBox4.Controls.Add(this.textboxTimerStatic);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.radioTimerBoth);
            this.groupBox4.Controls.Add(this.radioTimerPerLetter);
            this.groupBox4.Controls.Add(this.radioTimerStatic);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(8, 176);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(251, 156);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Timing";
            // 
            // radioTimerNone
            // 
            this.radioTimerNone.AutoSize = true;
            this.radioTimerNone.Location = new System.Drawing.Point(21, 20);
            this.radioTimerNone.Name = "radioTimerNone";
            this.radioTimerNone.Size = new System.Drawing.Size(64, 17);
            this.radioTimerNone.TabIndex = 7;
            this.radioTimerNone.TabStop = true;
            this.radioTimerNone.Text = "No timer";
            this.radioTimerNone.UseVisualStyleBackColor = true;
            this.radioTimerNone.CheckedChanged += new System.EventHandler(this.radioTimerNone_CheckedChanged);
            // 
            // textboxSecondsPerLetter
            // 
            this.textboxSecondsPerLetter.Location = new System.Drawing.Point(195, 128);
            this.textboxSecondsPerLetter.MaxLength = 2;
            this.textboxSecondsPerLetter.Name = "textboxSecondsPerLetter";
            this.textboxSecondsPerLetter.Size = new System.Drawing.Size(32, 20);
            this.textboxSecondsPerLetter.TabIndex = 6;
            this.textboxSecondsPerLetter.TextChanged += new System.EventHandler(this.textboxSecondsPerLetter_TextChanged);
            // 
            // textboxTimerStatic
            // 
            this.textboxTimerStatic.Location = new System.Drawing.Point(195, 105);
            this.textboxTimerStatic.MaxLength = 2;
            this.textboxTimerStatic.Name = "textboxTimerStatic";
            this.textboxTimerStatic.Size = new System.Drawing.Size(32, 20);
            this.textboxTimerStatic.TabIndex = 4;
            this.textboxTimerStatic.TextChanged += new System.EventHandler(this.textboxTimerStatic_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Static time value (10-60 seconds)";
            // 
            // radioTimerBoth
            // 
            this.radioTimerBoth.AutoSize = true;
            this.radioTimerBoth.Location = new System.Drawing.Point(21, 86);
            this.radioTimerBoth.Name = "radioTimerBoth";
            this.radioTimerBoth.Size = new System.Drawing.Size(177, 17);
            this.radioTimerBoth.TabIndex = 2;
            this.radioTimerBoth.TabStop = true;
            this.radioTimerBoth.Text = "Static value + seconds per letter";
            this.radioTimerBoth.UseVisualStyleBackColor = true;
            this.radioTimerBoth.CheckedChanged += new System.EventHandler(this.radioTimerBoth_CheckedChanged);
            // 
            // radioTimerPerLetter
            // 
            this.radioTimerPerLetter.AutoSize = true;
            this.radioTimerPerLetter.Location = new System.Drawing.Point(21, 63);
            this.radioTimerPerLetter.Name = "radioTimerPerLetter";
            this.radioTimerPerLetter.Size = new System.Drawing.Size(111, 17);
            this.radioTimerPerLetter.TabIndex = 1;
            this.radioTimerPerLetter.TabStop = true;
            this.radioTimerPerLetter.Text = "Seconds per letter";
            this.radioTimerPerLetter.UseVisualStyleBackColor = true;
            this.radioTimerPerLetter.CheckedChanged += new System.EventHandler(this.radioTimerPerLetter_CheckedChanged);
            // 
            // radioTimerStatic
            // 
            this.radioTimerStatic.AutoSize = true;
            this.radioTimerStatic.Location = new System.Drawing.Point(21, 40);
            this.radioTimerStatic.Name = "radioTimerStatic";
            this.radioTimerStatic.Size = new System.Drawing.Size(103, 17);
            this.radioTimerStatic.TabIndex = 0;
            this.radioTimerStatic.TabStop = true;
            this.radioTimerStatic.Text = "Static time value";
            this.radioTimerStatic.UseVisualStyleBackColor = true;
            this.radioTimerStatic.CheckedChanged += new System.EventHandler(this.radioTimerStatic_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Seconds per letter (3-10)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkboxAwardBonusTime);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textboxBonusWords);
            this.groupBox3.Controls.Add(this.textboxBonusTime);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(7, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 96);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bonus Time";
            // 
            // checkboxAwardBonusTime
            // 
            this.checkboxAwardBonusTime.AutoSize = true;
            this.checkboxAwardBonusTime.Location = new System.Drawing.Point(22, 20);
            this.checkboxAwardBonusTime.Name = "checkboxAwardBonusTime";
            this.checkboxAwardBonusTime.Size = new System.Drawing.Size(110, 17);
            this.checkboxAwardBonusTime.TabIndex = 6;
            this.checkboxAwardBonusTime.Text = "Award bonus time";
            this.checkboxAwardBonusTime.UseVisualStyleBackColor = true;
            this.checkboxAwardBonusTime.CheckedChanged += new System.EventHandler(this.checkboxAwardBonusTime_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "for every";
            // 
            // textboxBonusWords
            // 
            this.textboxBonusWords.Location = new System.Drawing.Point(91, 68);
            this.textboxBonusWords.MaxLength = 3;
            this.textboxBonusWords.Name = "textboxBonusWords";
            this.textboxBonusWords.Size = new System.Drawing.Size(32, 20);
            this.textboxBonusWords.TabIndex = 3;
            this.textboxBonusWords.TextChanged += new System.EventHandler(this.textboxBonusWords_TextChanged);
            // 
            // textboxBonusTime
            // 
            this.textboxBonusTime.Location = new System.Drawing.Point(91, 42);
            this.textboxBonusTime.MaxLength = 2;
            this.textboxBonusTime.Name = "textboxBonusTime";
            this.textboxBonusTime.Size = new System.Drawing.Size(32, 20);
            this.textboxBonusTime.TabIndex = 1;
            this.textboxBonusTime.TextChanged += new System.EventHandler(this.textboxBonusTime_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(127, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "(10-60) seconds";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Add";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(127, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "(5-100) words";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textboxLetterPool);
            this.groupBox2.Controls.Add(this.radioLetterPoolStatic);
            this.groupBox2.Controls.Add(this.radioLetterPoolRandom);
            this.groupBox2.Location = new System.Drawing.Point(7, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 67);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Letter Pool";
            // 
            // textboxLetterPool
            // 
            this.textboxLetterPool.Location = new System.Drawing.Point(106, 40);
            this.textboxLetterPool.MaxLength = 2;
            this.textboxLetterPool.Name = "textboxLetterPool";
            this.textboxLetterPool.Size = new System.Drawing.Size(32, 20);
            this.textboxLetterPool.TabIndex = 2;
            this.textboxLetterPool.TextChanged += new System.EventHandler(this.textboxLetterPool_TextChanged);
            // 
            // radioLetterPoolStatic
            // 
            this.radioLetterPoolStatic.AutoSize = true;
            this.radioLetterPoolStatic.Location = new System.Drawing.Point(21, 41);
            this.radioLetterPoolStatic.Name = "radioLetterPoolStatic";
            this.radioLetterPoolStatic.Size = new System.Drawing.Size(82, 17);
            this.radioLetterPoolStatic.TabIndex = 1;
            this.radioLetterPoolStatic.TabStop = true;
            this.radioLetterPoolStatic.Text = "Static (6-10)";
            this.radioLetterPoolStatic.UseVisualStyleBackColor = true;
            this.radioLetterPoolStatic.CheckedChanged += new System.EventHandler(this.radioLetterPoolStatic_CheckedChanged);
            // 
            // radioLetterPoolRandom
            // 
            this.radioLetterPoolRandom.AutoSize = true;
            this.radioLetterPoolRandom.Location = new System.Drawing.Point(21, 19);
            this.radioLetterPoolRandom.Name = "radioLetterPoolRandom";
            this.radioLetterPoolRandom.Size = new System.Drawing.Size(65, 17);
            this.radioLetterPoolRandom.TabIndex = 0;
            this.radioLetterPoolRandom.TabStop = true;
            this.radioLetterPoolRandom.Text = "Random";
            this.radioLetterPoolRandom.UseVisualStyleBackColor = true;
            this.radioLetterPoolRandom.CheckedChanged += new System.EventHandler(this.radioLetterPoolRandom_CheckedChanged);
            // 
            // checkboxAllowRepeats
            // 
            this.checkboxAllowRepeats.AutoSize = true;
            this.checkboxAllowRepeats.Location = new System.Drawing.Point(28, 377);
            this.checkboxAllowRepeats.Name = "checkboxAllowRepeats";
            this.checkboxAllowRepeats.Size = new System.Drawing.Size(127, 17);
            this.checkboxAllowRepeats.TabIndex = 4;
            this.checkboxAllowRepeats.Text = "Allow words to repeat";
            this.checkboxAllowRepeats.UseVisualStyleBackColor = true;
            this.checkboxAllowRepeats.CheckedChanged += new System.EventHandler(this.checkboxAllowRepeats_CheckedChanged);
            // 
            // checkboxPlaySounds
            // 
            this.checkboxPlaySounds.AutoSize = true;
            this.checkboxPlaySounds.Location = new System.Drawing.Point(28, 357);
            this.checkboxPlaySounds.Name = "checkboxPlaySounds";
            this.checkboxPlaySounds.Size = new System.Drawing.Size(113, 17);
            this.checkboxPlaySounds.TabIndex = 3;
            this.checkboxPlaySounds.Text = "Play sound effects";
            this.checkboxPlaySounds.UseVisualStyleBackColor = true;
            this.checkboxPlaySounds.CheckedChanged += new System.EventHandler(this.checkboxPlaySounds_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(8, 334);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(251, 70);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Other Settings";
            // 
            // buttonDefaultSettings
            // 
            this.buttonDefaultSettings.Location = new System.Drawing.Point(75, 412);
            this.buttonDefaultSettings.Name = "buttonDefaultSettings";
            this.buttonDefaultSettings.Size = new System.Drawing.Size(115, 23);
            this.buttonDefaultSettings.TabIndex = 6;
            this.buttonDefaultSettings.Text = "Default Settings";
            this.buttonDefaultSettings.UseVisualStyleBackColor = true;
            this.buttonDefaultSettings.Click += new System.EventHandler(this.buttonDefaultSettings_Click);
            // 
            // Configure
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(266, 475);
            this.Controls.Add(this.buttonDefaultSettings);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkboxAllowRepeats);
            this.Controls.Add(this.checkboxPlaySounds);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "Configure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure";
            this.Load += new System.EventHandler(this.Configure_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textboxSecondsPerLetter;
        private System.Windows.Forms.TextBox textboxTimerStatic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioTimerBoth;
        private System.Windows.Forms.RadioButton radioTimerPerLetter;
        private System.Windows.Forms.RadioButton radioTimerStatic;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textboxBonusWords;
        private System.Windows.Forms.TextBox textboxBonusTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textboxLetterPool;
        private System.Windows.Forms.RadioButton radioLetterPoolStatic;
        private System.Windows.Forms.RadioButton radioLetterPoolRandom;
        private System.Windows.Forms.CheckBox checkboxAllowRepeats;
        private System.Windows.Forms.CheckBox checkboxPlaySounds;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonDefaultSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioTimerNone;
        private System.Windows.Forms.CheckBox checkboxAwardBonusTime;
    }
}