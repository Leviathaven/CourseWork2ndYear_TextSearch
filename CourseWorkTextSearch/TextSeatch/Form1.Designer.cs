namespace CourseWorkTextSearch
{
    partial class WorkSpace
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rtbData = new System.Windows.Forms.RichTextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnOpenDoc = new System.Windows.Forms.Button();
            this.btnDamerauLevenshtein = new System.Windows.Forms.Button();
            this.lblrez = new System.Windows.Forms.Label();
            this.btnLevenshtein = new System.Windows.Forms.Button();
            this.insertDistance = new System.Windows.Forms.TextBox();
            this.labelWord = new System.Windows.Forms.Label();
            this.labelDist = new System.Windows.Forms.Label();
            this.errorProviderDL = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderL = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_Insert_New_Text_RTB = new System.Windows.Forms.Button();
            this.btnHamming = new System.Windows.Forms.Button();
            this.errorProviderH = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnJaroWinkler = new System.Windows.Forms.Button();
            this.errorProviderJW = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnGoToSoundex = new System.Windows.Forms.Button();
            this.btnDice = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSoundex = new System.Windows.Forms.Button();
            this.errorProviderD = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderS = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblMaybeYouSearched = new System.Windows.Forms.Label();
            this.txtElapsedTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderJW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderS)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbData
            // 
            this.rtbData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbData.Location = new System.Drawing.Point(13, 13);
            this.rtbData.MaximumSize = new System.Drawing.Size(1000, 850);
            this.rtbData.Name = "rtbData";
            this.rtbData.ReadOnly = true;
            this.rtbData.Size = new System.Drawing.Size(814, 687);
            this.rtbData.TabIndex = 1;
            this.rtbData.Text = "";
            // 
            // txtInput
            // 
            this.txtInput.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtInput.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtInput.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtInput.Location = new System.Drawing.Point(903, 93);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(268, 22);
            this.txtInput.TabIndex = 2;
            // 
            // btnOpenDoc
            // 
            this.btnOpenDoc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOpenDoc.Location = new System.Drawing.Point(845, 637);
            this.btnOpenDoc.MaximumSize = new System.Drawing.Size(200, 110);
            this.btnOpenDoc.Name = "btnOpenDoc";
            this.btnOpenDoc.Size = new System.Drawing.Size(122, 63);
            this.btnOpenDoc.TabIndex = 3;
            this.btnOpenDoc.Text = "Открыть документ";
            this.btnOpenDoc.UseVisualStyleBackColor = true;
            this.btnOpenDoc.Click += new System.EventHandler(this.btnOpenDoc_Click);
            // 
            // btnDamerauLevenshtein
            // 
            this.btnDamerauLevenshtein.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDamerauLevenshtein.Location = new System.Drawing.Point(1061, 141);
            this.btnDamerauLevenshtein.MaximumSize = new System.Drawing.Size(250, 100);
            this.btnDamerauLevenshtein.Name = "btnDamerauLevenshtein";
            this.btnDamerauLevenshtein.Size = new System.Drawing.Size(200, 51);
            this.btnDamerauLevenshtein.TabIndex = 4;
            this.btnDamerauLevenshtein.Text = "Расстояние Дамерау-Левенштейна";
            this.btnDamerauLevenshtein.UseVisualStyleBackColor = true;
            this.btnDamerauLevenshtein.Click += new System.EventHandler(this.btnDamerauLevenshtein_Click);
            // 
            // lblrez
            // 
            this.lblrez.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblrez.AutoSize = true;
            this.lblrez.Location = new System.Drawing.Point(900, 417);
            this.lblrez.Name = "lblrez";
            this.lblrez.Size = new System.Drawing.Size(0, 17);
            this.lblrez.TabIndex = 5;
            // 
            // btnLevenshtein
            // 
            this.btnLevenshtein.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLevenshtein.Location = new System.Drawing.Point(1061, 198);
            this.btnLevenshtein.MaximumSize = new System.Drawing.Size(250, 100);
            this.btnLevenshtein.Name = "btnLevenshtein";
            this.btnLevenshtein.Size = new System.Drawing.Size(200, 51);
            this.btnLevenshtein.TabIndex = 7;
            this.btnLevenshtein.Text = "Расстояние Левенштейна";
            this.btnLevenshtein.UseVisualStyleBackColor = true;
            this.btnLevenshtein.Click += new System.EventHandler(this.BtnLevenshtein_Click);
            // 
            // insertDistance
            // 
            this.insertDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.insertDistance.Location = new System.Drawing.Point(1220, 93);
            this.insertDistance.MaximumSize = new System.Drawing.Size(150, 50);
            this.insertDistance.Name = "insertDistance";
            this.insertDistance.Size = new System.Drawing.Size(133, 22);
            this.insertDistance.TabIndex = 8;
            // 
            // labelWord
            // 
            this.labelWord.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelWord.AutoSize = true;
            this.labelWord.Location = new System.Drawing.Point(900, 41);
            this.labelWord.Name = "labelWord";
            this.labelWord.Size = new System.Drawing.Size(258, 17);
            this.labelWord.TabIndex = 9;
            this.labelWord.Text = "Введите слово, которое хотите найти";
            // 
            // labelDist
            // 
            this.labelDist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDist.Location = new System.Drawing.Point(1217, 13);
            this.labelDist.Name = "labelDist";
            this.labelDist.Size = new System.Drawing.Size(153, 70);
            this.labelDist.TabIndex = 10;
            this.labelDist.Text = "Введите максимально допустимое расстояние поиска";
            // 
            // errorProviderDL
            // 
            this.errorProviderDL.ContainerControl = this;
            // 
            // errorProviderL
            // 
            this.errorProviderL.ContainerControl = this;
            // 
            // btn_Insert_New_Text_RTB
            // 
            this.btn_Insert_New_Text_RTB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Insert_New_Text_RTB.Location = new System.Drawing.Point(845, 392);
            this.btn_Insert_New_Text_RTB.MaximumSize = new System.Drawing.Size(260, 110);
            this.btn_Insert_New_Text_RTB.Name = "btn_Insert_New_Text_RTB";
            this.btn_Insert_New_Text_RTB.Size = new System.Drawing.Size(166, 97);
            this.btn_Insert_New_Text_RTB.TabIndex = 13;
            this.btn_Insert_New_Text_RTB.Text = "Нажмите для вставки своего текста";
            this.btn_Insert_New_Text_RTB.UseVisualStyleBackColor = true;
            this.btn_Insert_New_Text_RTB.Click += new System.EventHandler(this.btn_Insert_New_Text_RTB_Click);
            // 
            // btnHamming
            // 
            this.btnHamming.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHamming.Location = new System.Drawing.Point(1061, 255);
            this.btnHamming.MaximumSize = new System.Drawing.Size(250, 100);
            this.btnHamming.Name = "btnHamming";
            this.btnHamming.Size = new System.Drawing.Size(200, 51);
            this.btnHamming.TabIndex = 14;
            this.btnHamming.Text = "Расстояние Хэмминга";
            this.btnHamming.UseVisualStyleBackColor = true;
            this.btnHamming.Click += new System.EventHandler(this.btnHamming_Click);
            // 
            // errorProviderH
            // 
            this.errorProviderH.ContainerControl = this;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(845, 502);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(166, 72);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "Редактировать содержимое";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnJaroWinkler
            // 
            this.btnJaroWinkler.Location = new System.Drawing.Point(1061, 312);
            this.btnJaroWinkler.Name = "btnJaroWinkler";
            this.btnJaroWinkler.Size = new System.Drawing.Size(200, 51);
            this.btnJaroWinkler.TabIndex = 16;
            this.btnJaroWinkler.Text = "Расстояние Джаро-Винклера";
            this.btnJaroWinkler.UseVisualStyleBackColor = true;
            this.btnJaroWinkler.Click += new System.EventHandler(this.btnJaroWinkler_Click);
            // 
            // errorProviderJW
            // 
            this.errorProviderJW.ContainerControl = this;
            // 
            // btnGoToSoundex
            // 
            this.btnGoToSoundex.Location = new System.Drawing.Point(1061, 369);
            this.btnGoToSoundex.Name = "btnGoToSoundex";
            this.btnGoToSoundex.Size = new System.Drawing.Size(200, 23);
            this.btnGoToSoundex.TabIndex = 17;
            this.btnGoToSoundex.Text = "Следующая страница";
            this.btnGoToSoundex.UseVisualStyleBackColor = true;
            this.btnGoToSoundex.Click += new System.EventHandler(this.btnGoToSoundex_Click);
            // 
            // btnDice
            // 
            this.btnDice.Location = new System.Drawing.Point(1061, 141);
            this.btnDice.Name = "btnDice";
            this.btnDice.Size = new System.Drawing.Size(200, 51);
            this.btnDice.TabIndex = 18;
            this.btnDice.Text = "Коэфициент Дайса";
            this.btnDice.UseVisualStyleBackColor = true;
            this.btnDice.Visible = false;
            this.btnDice.Click += new System.EventHandler(this.btnDice_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1061, 255);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(200, 23);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Назад к подсчёту метрик";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSoundex
            // 
            this.btnSoundex.Location = new System.Drawing.Point(1061, 141);
            this.btnSoundex.Name = "btnSoundex";
            this.btnSoundex.Size = new System.Drawing.Size(200, 51);
            this.btnSoundex.TabIndex = 20;
            this.btnSoundex.Text = "Поиск при помощи алгоритма Soundex ";
            this.btnSoundex.UseVisualStyleBackColor = true;
            this.btnSoundex.Visible = false;
            this.btnSoundex.Click += new System.EventHandler(this.btnSoundex_Click);
            // 
            // errorProviderD
            // 
            this.errorProviderD.ContainerControl = this;
            // 
            // errorProviderS
            // 
            this.errorProviderS.ContainerControl = this;
            // 
            // lblMaybeYouSearched
            // 
            this.lblMaybeYouSearched.Location = new System.Drawing.Point(833, 141);
            this.lblMaybeYouSearched.Name = "lblMaybeYouSearched";
            this.lblMaybeYouSearched.Size = new System.Drawing.Size(207, 57);
            this.lblMaybeYouSearched.TabIndex = 21;
            this.lblMaybeYouSearched.Text = "Возможно, вы искали: ";
            // 
            // txtElapsedTime
            // 
            this.txtElapsedTime.Location = new System.Drawing.Point(1098, 527);
            this.txtElapsedTime.Name = "txtElapsedTime";
            this.txtElapsedTime.ReadOnly = true;
            this.txtElapsedTime.Size = new System.Drawing.Size(184, 22);
            this.txtElapsedTime.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1079, 502);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Время выполнения алгоритма: ";
            // 
            // txtPercent
            // 
            this.txtPercent.Location = new System.Drawing.Point(845, 312);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.ReadOnly = true;
            this.txtPercent.Size = new System.Drawing.Size(166, 22);
            this.txtPercent.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(833, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Процент правильных слов";
            // 
            // WorkSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 712);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPercent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtElapsedTime);
            this.Controls.Add(this.lblMaybeYouSearched);
            this.Controls.Add(this.btnSoundex);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDice);
            this.Controls.Add(this.btnGoToSoundex);
            this.Controls.Add(this.btnJaroWinkler);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnHamming);
            this.Controls.Add(this.btn_Insert_New_Text_RTB);
            this.Controls.Add(this.labelDist);
            this.Controls.Add(this.labelWord);
            this.Controls.Add(this.insertDistance);
            this.Controls.Add(this.btnLevenshtein);
            this.Controls.Add(this.lblrez);
            this.Controls.Add(this.btnDamerauLevenshtein);
            this.Controls.Add(this.btnOpenDoc);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.rtbData);
            this.MaximumSize = new System.Drawing.Size(1400, 759);
            this.Name = "WorkSpace";
            this.Text = "Алгоритмы нечёткого поиска в тексте";
            this.Load += new System.EventHandler(this.WorkSpace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderJW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtbData;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnOpenDoc;
        private System.Windows.Forms.Button btnDamerauLevenshtein;
        private System.Windows.Forms.Label lblrez;
        private System.Windows.Forms.Button btnLevenshtein;
        private System.Windows.Forms.TextBox insertDistance;
        private System.Windows.Forms.Label labelWord;
        private System.Windows.Forms.Label labelDist;
        private System.Windows.Forms.ErrorProvider errorProviderDL;
        private System.Windows.Forms.ErrorProvider errorProviderL;
        private System.Windows.Forms.Button btnHamming;
        private System.Windows.Forms.Button btn_Insert_New_Text_RTB;
        private System.Windows.Forms.ErrorProvider errorProviderH;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnJaroWinkler;
        private System.Windows.Forms.ErrorProvider errorProviderJW;
        private System.Windows.Forms.Button btnSoundex;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDice;
        private System.Windows.Forms.Button btnGoToSoundex;
        private System.Windows.Forms.ErrorProvider errorProviderD;
        private System.Windows.Forms.ErrorProvider errorProviderS;
        private System.Windows.Forms.Label lblMaybeYouSearched;
        private System.Windows.Forms.TextBox txtElapsedTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPercent;
    }
}

