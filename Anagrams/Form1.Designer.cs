namespace Anagrams
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.textboxScrambled = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textboxWord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.listboxWords = new System.Windows.Forms.ListBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonDone = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.labelWordsFound = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.labelPossibleWords = new System.Windows.Forms.Label();
            this.timerCountdown = new System.Windows.Forms.Timer(this.components);
            this.smoothProgressBar = new SmoothProgressBar.SmoothProgressBar();
            this.buttonConfigure = new System.Windows.Forms.Button();
            this.groupboxStats = new System.Windows.Forms.GroupBox();
            this.labelGameStats = new System.Windows.Forms.Label();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.groupboxStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // textboxScrambled
            // 
            this.textboxScrambled.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxScrambled.Location = new System.Drawing.Point(96, 12);
            this.textboxScrambled.Margin = new System.Windows.Forms.Padding(4);
            this.textboxScrambled.Name = "textboxScrambled";
            this.textboxScrambled.ReadOnly = true;
            this.textboxScrambled.Size = new System.Drawing.Size(292, 26);
            this.textboxScrambled.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Letters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Word";
            // 
            // textboxWord
            // 
            this.textboxWord.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxWord.Location = new System.Drawing.Point(96, 52);
            this.textboxWord.Margin = new System.Windows.Forms.Padding(4);
            this.textboxWord.Name = "textboxWord";
            this.textboxWord.Size = new System.Drawing.Size(292, 26);
            this.textboxWord.TabIndex = 12;
            this.textboxWord.TextChanged += new System.EventHandler(this.textboxWord_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(396, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Score";
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoints.Location = new System.Drawing.Point(564, 55);
            this.labelPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(59, 20);
            this.labelPoints.TabIndex = 20;
            this.labelPoints.Text = "99999";
            // 
            // listboxWords
            // 
            this.listboxWords.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listboxWords.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listboxWords.FormattingEnabled = true;
            this.listboxWords.ItemHeight = 18;
            this.listboxWords.Location = new System.Drawing.Point(96, 128);
            this.listboxWords.Margin = new System.Windows.Forms.Padding(4);
            this.listboxWords.Name = "listboxWords";
            this.listboxWords.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listboxWords.Size = new System.Drawing.Size(292, 562);
            this.listboxWords.Sorted = true;
            this.listboxWords.TabIndex = 15;
            this.listboxWords.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listboxWords_DrawItem);
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(434, 162);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(235, 42);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "New Game";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonDone
            // 
            this.buttonDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDone.Location = new System.Drawing.Point(434, 647);
            this.buttonDone.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(235, 42);
            this.buttonDone.TabIndex = 23;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSubmit.Location = new System.Drawing.Point(287, 133);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(100, 28);
            this.buttonSubmit.TabIndex = 16;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(396, 127);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 20);
            this.label15.TabIndex = 21;
            this.label15.Text = "Words Found";
            // 
            // labelWordsFound
            // 
            this.labelWordsFound.AutoSize = true;
            this.labelWordsFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWordsFound.Location = new System.Drawing.Point(564, 128);
            this.labelWordsFound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWordsFound.Name = "labelWordsFound";
            this.labelWordsFound.Size = new System.Drawing.Size(39, 20);
            this.labelWordsFound.TabIndex = 22;
            this.labelWordsFound.Text = "999";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 97);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 20);
            this.label19.TabIndex = 13;
            this.label19.Text = "Remaining";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(397, 16);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(118, 20);
            this.label20.TabIndex = 17;
            this.label20.Text = "Possible Words";
            // 
            // labelPossibleWords
            // 
            this.labelPossibleWords.AutoSize = true;
            this.labelPossibleWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPossibleWords.Location = new System.Drawing.Point(564, 16);
            this.labelPossibleWords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPossibleWords.Name = "labelPossibleWords";
            this.labelPossibleWords.Size = new System.Drawing.Size(74, 20);
            this.labelPossibleWords.TabIndex = 18;
            this.labelPossibleWords.Text = "999,999";
            // 
            // timerCountdown
            // 
            this.timerCountdown.Tick += new System.EventHandler(this.timerCountdown_Tick);
            // 
            // smoothProgressBar
            // 
            this.smoothProgressBar.BackColor = System.Drawing.Color.White;
            this.smoothProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smoothProgressBar.Location = new System.Drawing.Point(96, 92);
            this.smoothProgressBar.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.smoothProgressBar.Maximum = 100;
            this.smoothProgressBar.Minimum = 0;
            this.smoothProgressBar.Name = "smoothProgressBar";
            this.smoothProgressBar.ProgressBarColor = System.Drawing.Color.DeepSkyBlue;
            this.smoothProgressBar.Size = new System.Drawing.Size(293, 28);
            this.smoothProgressBar.TabIndex = 14;
            this.smoothProgressBar.Value = 0;
            // 
            // buttonConfigure
            // 
            this.buttonConfigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfigure.Location = new System.Drawing.Point(434, 597);
            this.buttonConfigure.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConfigure.Name = "buttonConfigure";
            this.buttonConfigure.Size = new System.Drawing.Size(235, 42);
            this.buttonConfigure.TabIndex = 24;
            this.buttonConfigure.Text = "Configure";
            this.buttonConfigure.UseVisualStyleBackColor = true;
            this.buttonConfigure.Click += new System.EventHandler(this.buttonConfigure_Click);
            // 
            // groupboxStats
            // 
            this.groupboxStats.Controls.Add(this.labelGameStats);
            this.groupboxStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupboxStats.Location = new System.Drawing.Point(396, 263);
            this.groupboxStats.Margin = new System.Windows.Forms.Padding(4);
            this.groupboxStats.Name = "groupboxStats";
            this.groupboxStats.Padding = new System.Windows.Forms.Padding(4);
            this.groupboxStats.Size = new System.Drawing.Size(308, 324);
            this.groupboxStats.TabIndex = 25;
            this.groupboxStats.TabStop = false;
            this.groupboxStats.Text = "End-of-Game Statistics";
            this.groupboxStats.Visible = false;
            // 
            // labelGameStats
            // 
            this.labelGameStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameStats.Location = new System.Drawing.Point(10, 22);
            this.labelGameStats.Name = "labelGameStats";
            this.labelGameStats.Size = new System.Drawing.Size(288, 290);
            this.labelGameStats.TabIndex = 0;
            this.labelGameStats.Text = "label4";
            this.labelGameStats.Visible = false;
            // 
            // buttonSolve
            // 
            this.buttonSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSolve.Location = new System.Drawing.Point(434, 212);
            this.buttonSolve.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(235, 42);
            this.buttonSolve.TabIndex = 26;
            this.buttonSolve.Text = "Solve";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 700);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.groupboxStats);
            this.Controls.Add(this.buttonConfigure);
            this.Controls.Add(this.labelPossibleWords);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.labelWordsFound);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textboxWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxScrambled);
            this.Controls.Add(this.smoothProgressBar);
            this.Controls.Add(this.listboxWords);
            this.Controls.Add(this.buttonSubmit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anagrams";
            this.groupboxStats.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxScrambled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textboxWord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.ListBox listboxWords;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelWordsFound;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label labelPossibleWords;
        private System.Windows.Forms.Timer timerCountdown;
        private SmoothProgressBar.SmoothProgressBar smoothProgressBar;
        private System.Windows.Forms.Button buttonConfigure;
        private System.Windows.Forms.GroupBox groupboxStats;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Label labelGameStats;
    }
}

