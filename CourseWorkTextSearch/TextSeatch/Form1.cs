using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace CourseWorkTextSearch
{
    public partial class WorkSpace : Form
    {
        public WorkSpace()
        {
            InitializeComponent();
        }

        private void btnOpenDoc_Click(object sender, EventArgs e)
        {
            rtbData.ReadOnly = true;
            rtbData.BackColor = Color.Beige;
            if (btn_Insert_New_Text_RTB.Text == "Нажмите для загрузки текста в систему и стандартизации содержимого")
                btn_Insert_New_Text_RTB.Text = "Нажмите для вставки своего текста";
            if (btnEdit.Text == "Закрепите отредактированный текст")
                btnEdit.Text = "Редактировать содержимое";
            using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "Word Document|*.docx|Text Document|*.txt|Word 97-2003|*.doc" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    object readOnly = false;
                    object visible = true;
                    object save = false;
                    object fileName = ofd.FileName;
                    object newTemplate = false;
                    object docType = 0;
                    object missing = Type.Missing;
                    Microsoft.Office.Interop.Word._Document doc;
                    Microsoft.Office.Interop.Word._Application app = new Microsoft.Office.Interop.Word.Application() { Visible = false };
                    doc = app.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing
                                            , ref visible, ref missing, ref missing, ref missing, ref missing);
                    doc.ActiveWindow.Selection.WholeStory();
                    doc.ActiveWindow.Selection.Copy();
                    IDataObject dataObject = Clipboard.GetDataObject();
                    rtbData.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();
                    app.Quit(ref missing, ref missing, ref missing);
                }
            }
            int newFontSize = 12; //размер
            FontStyle style = (FontStyle.Regular); //обычный
            rtbData.Font = new Font(rtbData.Font.FontFamily, (float)newFontSize, style);
            rtbData.SelectAll();
            rtbData.SelectionColor = Color.Black;
        }
        bool checkDotOrComma(char c)
        {
            return ((c == '.') || (c == ','));
        }

        void clearAll()
        {
            this.errorProviderDL.SetError(btnDamerauLevenshtein, "");
            this.errorProviderL.SetError(btnLevenshtein, "");
            this.errorProviderH.SetError(btnHamming, "");
            this.errorProviderJW.SetError(btnJaroWinkler, "");
            this.errorProviderS.SetError(btnSoundex, "");
            this.errorProviderD.SetError(btnDice, "");
            rtbData.SelectAll();
            rtbData.SelectionColor = Color.Black;
            lblMaybeYouSearched.Text = "Возможно вы искали: ";
            txtElapsedTime.Text = "";
           
        }

        bool checkIfNeededChar(char c)
        {
            int check = Convert.ToInt32(c);
            return ((check >= 48) && (check <= 57)) || ((check >= 65) && (check <= 90)) || ((check >= 97) && (check <= 122)) || ((check >= 1040) && (check <= 1103)) || (check == 1105) || (check == 1025);
        }

        private void btnDamerauLevenshtein_Click(object sender, EventArgs e)
        {
            clearAll();
            if ((rtbData.Text == "") || (txtInput.Text == "") || (insertDistance.Text == ""))
            {
                this.errorProviderDL.SetError(btnDamerauLevenshtein, "Одно из полей пустое");
            }
            else
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                List<string> allCloseWords = new List<string>();
                    string checker = txtInput.Text.ToString();
                    string editLines = rtbData.Text.ToString();
                    int maxDist = Convert.ToInt32(insertDistance.Text.ToString());
                    string checkFromRTF = "";
                    int i = 0;
                    int length = editLines.Length;
                    int minDist = Int32.MaxValue;
                    string closestWord = "";
                    while (i < length)
                    {
                        checkFromRTF = "";
                        while ((i < length) && (!checkIfNeededChar(editLines[i])))
                            i++;
                        while ((i < length) && (checkIfNeededChar(editLines[i])))
                        {
                            checkFromRTF += editLines[i];
                            i++;
                        }


                        int checkDist = Metricas.GetDamerauLevenshteinDistance(checker, checkFromRTF);
                    int checkDist1 = Metricas.GetDamerauLevenshteinDistance(checker, checkFromRTF.ToLower());
                    if (checkDist1 == minDist)
                    {
                        allCloseWords.Add(checkFromRTF);
                    }
                    else if (checkDist1 < minDist) {
                          allCloseWords.Clear();
                          allCloseWords.Add(checkFromRTF);
                          minDist = checkDist1; 
                          closestWord = checkFromRTF;
                    } 
                        if (checkDist <= maxDist)
                        {
                            int index;
                            if (checkDotOrComma(editLines[i - 1])) index = i - checkFromRTF.Length - 1;
                            else index = i - checkFromRTF.Length;
                            rtbData.Select(index, checkFromRTF.Length);
                            rtbData.SelectionColor = Color.Red;
                        }
                    }
                    if (closestWord == "")
                        lblMaybeYouSearched.Text = "Возможно вы искали: нет подходящих результатов";
                    else lblMaybeYouSearched.Text = "Возможно вы искали: " + closestWord + "?";
                   
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds);
                txtElapsedTime.Text = elapsedTime;
                int cnt = 0;
                foreach (string str in allCloseWords)
                {
                    if (str == closestWord) cnt++;
                }
                if (allCloseWords.Count == 0)
                    txtPercent.Text = Convert.ToString(0);
                else txtPercent.Text = Convert.ToString((Convert.ToDouble(cnt) / Convert.ToDouble(allCloseWords.Count)) * 100.0);
            }
        }

        private void BtnLevenshtein_Click(object sender, EventArgs e)
        {
            clearAll();
            if ((rtbData.Text == "") || (txtInput.Text == "") || (insertDistance.Text == ""))
            {
                this.errorProviderL.SetError(btnLevenshtein, "Одно из полей пустое");
            }
            else
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                List<string> allCloseWords = new List<string>();
                string checker = txtInput.Text.ToString();
                    string editLines = rtbData.Text.ToString();
                    int maxDist = Convert.ToInt32(insertDistance.Text.ToString());
                    int minDist = Int32.MaxValue;
                    string checkFromRTF = "";
                    int i = 0;
                    string closestWord = "";
                    int length = editLines.Length;
                    while (i < length)
                    {
                        checkFromRTF = "";
                        while ((i < length) && (!checkIfNeededChar(editLines[i])))
                            i++;
                        while ((i < length) && (checkIfNeededChar(editLines[i])))
                        {
                            checkFromRTF += editLines[i];
                            i++;
                        }
                        int checkDist = Metricas.GetLevenshteinDistance(checker, checkFromRTF);
                    int checkDist1 = Metricas.GetLevenshteinDistance(checker, checkFromRTF.ToLower());
                    if (checkDist1 == minDist)
                    {
                        allCloseWords.Add(checkFromRTF);
                    }
                    else if (checkDist1 < minDist)
                    {
                        allCloseWords.Clear();
                        allCloseWords.Add(checkFromRTF);
                        minDist = checkDist1;
                        closestWord = checkFromRTF;
                    }
                    if (checkDist <= maxDist)
                        {
                            int index;
                            if (checkDotOrComma(editLines[i - 1])) index = i - checkFromRTF.Length - 1;
                            else index = i - checkFromRTF.Length;
                            rtbData.Select(index, checkFromRTF.Length);
                            rtbData.SelectionColor = Color.Red;
                        }
                    }
                    if (closestWord == "")
                        lblMaybeYouSearched.Text = "Возможно вы искали: нет подходящих результатов";
                    else lblMaybeYouSearched.Text = "Возможно вы искали: " + closestWord + "?";
                 
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds);
                txtElapsedTime.Text = elapsedTime;
                int cnt = 0;
                foreach (string str in allCloseWords)
                {
                    if (str == closestWord) cnt++;
                }
                if (allCloseWords.Count == 0)
                    txtPercent.Text = Convert.ToString(0);
                else txtPercent.Text = Convert.ToString((Convert.ToDouble(cnt) / Convert.ToDouble(allCloseWords.Count)) * 100.0);
            }
        }

        private void btnHamming_Click(object sender, EventArgs e)
        {
            clearAll();
            if ((rtbData.Text == "") || (txtInput.Text == "") || (insertDistance.Text == ""))
            {
                this.errorProviderH.SetError(btnHamming, "Одно из полей пустое");
            }
            else
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                List<string> allCloseWords = new List<string>();
                string checker = txtInput.Text.ToString();
                    string editLines = rtbData.Text.ToString();
                    int maxDist = Convert.ToInt32(insertDistance.Text.ToString());
                    string checkFromRTF = "";
                int minDist = Int32.MaxValue;
                string closestWord = "";
                    int i = 0;
                    int length = editLines.Length;
                    while (i < length)
                    {
                        checkFromRTF = "";
                        while ((i < length) && (!checkIfNeededChar(editLines[i])))
                            i++;
                        while ((i < length) && (checkIfNeededChar(editLines[i])))
                        {
                            checkFromRTF += editLines[i];
                            i++;
                        }
                        int checkDist = Metricas.GetHammingDistance(checker, checkFromRTF);
                    if (checkDist != -1)
                    {
                        int checkDist1 = Metricas.GetHammingDistance(checker, checkFromRTF.ToLower());
                        if (checkDist1 == minDist)
                        {
                            allCloseWords.Add(checkFromRTF);
                        }
                        else if (checkDist1 < minDist)
                        {
                            allCloseWords.Clear();
                            allCloseWords.Add(checkFromRTF);
                            minDist = checkDist1;
                            closestWord = checkFromRTF;
                        }
                        if (checkDist <= maxDist) 
                        {

                            int index;
                            if (checkDotOrComma(editLines[i - 1])) index = i - checkFromRTF.Length - 1;
                            else index = i - checkFromRTF.Length;
                            rtbData.Select(index, checkFromRTF.Length);
                            rtbData.SelectionColor = Color.Red;
                        }
                    }
                    }
                    if (closestWord == "")
                        lblMaybeYouSearched.Text = "Возможно вы искали: нет подходящих результатов";
                    else lblMaybeYouSearched.Text = "Возможно вы искали: " + closestWord + "?";
                
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds);
                txtElapsedTime.Text = elapsedTime;
                int cnt = 0;
                foreach (string str in allCloseWords)
                {
                    if (str == closestWord) cnt++;
                }
                if (allCloseWords.Count == 0)
                    txtPercent.Text = Convert.ToString(0);
                else txtPercent.Text = Convert.ToString((Convert.ToDouble(cnt) / Convert.ToDouble(allCloseWords.Count)) * 100.0);
            }
        }

        private void btn_Insert_New_Text_RTB_Click(object sender, EventArgs e)
        {
            rtbData.ReadOnly = true;
            rtbData.BackColor = Color.Beige;
            if (btnEdit.Text == "Закрепите отредактированный текст")
                btnEdit.Text = "Редактировать содержимое";
            if (btn_Insert_New_Text_RTB.Text == "Нажмите для вставки своего текста")
            {
                rtbData.Clear();
                btn_Insert_New_Text_RTB.Text = "Нажмите для загрузки текста в систему и стандартизации содержимого";
                rtbData.ReadOnly = false;
                rtbData.BackColor = Color.White;
            }
            else
            {
                btn_Insert_New_Text_RTB.Text = "Нажмите для вставки своего текста";
                rtbData.BackColor = Color.Beige;
                int newFontSize = 12; //размер
                FontStyle style = (FontStyle.Regular); //обычный
                rtbData.Font = new Font(rtbData.Font.FontFamily, (float)newFontSize, style);
                rtbData.SelectAll();
                rtbData.SelectionColor = Color.Black;
                rtbData.ReadOnly = true;
            }
        }

        private void WorkSpace_Load(object sender, EventArgs e)
        {
            rtbData.BackColor = Color.Beige;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            rtbData.ReadOnly = true;
            rtbData.BackColor = Color.Beige;
            if (btn_Insert_New_Text_RTB.Text == "Нажмите для загрузки текста в систему и стандартизации содержимого")
                btn_Insert_New_Text_RTB.Text = "Нажмите для вставки своего текста";
            if (btnEdit.Text == "Редактировать содержимое")
            {
                btnEdit.Text = "Закрепите отредактированный текст";
                rtbData.ReadOnly = false;
                rtbData.BackColor = Color.White;
            }
            else
            {
                btnEdit.Text = "Редактировать содержимое";
                rtbData.BackColor = Color.Beige;
                int newFontSize = 12; //размер
                FontStyle style = (FontStyle.Regular); //обычный
                rtbData.Font = new Font(rtbData.Font.FontFamily, (float)newFontSize, style);
                rtbData.SelectAll();
                rtbData.SelectionColor = Color.Black;
                rtbData.ReadOnly = true;
            }
        }

        private void btnJaroWinkler_Click(object sender, EventArgs e)
        {
            clearAll();

            if ((rtbData.Text == "") || (txtInput.Text == "") || (insertDistance.Text == ""))
            {
                this.errorProviderJW.SetError(btnJaroWinkler, "Одно из полей пустое");
            }
            else
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                List<string> allCloseWords = new List<string>();
                string checker = txtInput.Text.ToString();
                    string editLines = rtbData.Text.ToString();
                    string insertedDist = insertDistance.Text.ToString();
                    int indexOfDot = insertedDist.IndexOf('.');
                    double maxDist = 0.0;
                    double minDist = 0.0;
                    string closestWord = "";
                    if (indexOfDot != -1)
                    {
                        string leftNum = "";
                        for (int t = 0; t < indexOfDot; t++)
                        {
                            leftNum += insertedDist[t];
                        }
                        string rightNum = "";
                        int u = 1;
                        for (int t = indexOfDot + 1; t < insertedDist.Length; t++)
                        {
                            rightNum += insertedDist[t];
                            u *= 10;
                        }
                        maxDist = Convert.ToDouble(leftNum) + Convert.ToDouble(rightNum) / u;
                    }
                    else maxDist = Convert.ToDouble(insertedDist);
                    string checkFromRTF = "";
                    int i = 0;
                    int length = editLines.Length;
                    while (i < length)
                    {
                        checkFromRTF = "";
                        while ((i < length) && (!checkIfNeededChar(editLines[i])))
                            i++;
                        while ((i < length) && (checkIfNeededChar(editLines[i])))
                        {
                            checkFromRTF += editLines[i];
                            i++;
                        }
                        double checkDist = JaroWinkler.GetJaroWinklerDistance(checker, checkFromRTF);
                    double checkDist1 = JaroWinkler.GetJaroWinklerDistance(checker, checkFromRTF.ToLower());
                    if (checkDist1 == minDist)
                    {
                        allCloseWords.Add(checkFromRTF);
                    }
                    else if (checkDist > minDist)
                    {
                        allCloseWords.Clear();
                        allCloseWords.Add(checkFromRTF);
                        minDist = checkDist1;
                        closestWord = checkFromRTF;
                    }
                    if (checkDist >= maxDist)
                        {
                            int index;
                            if (checkDotOrComma(editLines[i - 1])) index = i - checkFromRTF.Length - 1;
                            else index = i - checkFromRTF.Length;
                            rtbData.Select(index, checkFromRTF.Length);
                            rtbData.SelectionColor = Color.Red;
                        }
                    }
                    if (closestWord == "")
                        lblMaybeYouSearched.Text = "Возможно вы искали: нет подходящих результатов";
                    else lblMaybeYouSearched.Text = "Возможно вы искали: " + closestWord + "?";
               
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds);
                txtElapsedTime.Text = elapsedTime;
                int cnt = 0;
                foreach (string str in allCloseWords)
                {
                    if (str == closestWord) cnt++;
                }
                if (allCloseWords.Count == 0)
                    txtPercent.Text = Convert.ToString(0);
                else txtPercent.Text = Convert.ToString((Convert.ToDouble(cnt) / Convert.ToDouble(allCloseWords.Count)) * 100.0);
            }
        }

        private void btnGoToSoundex_Click(object sender, EventArgs e)
        {
            if (btnJaroWinkler.Visible)
            {
                btnJaroWinkler.Visible = false;
                btnHamming.Visible = false;
                btnLevenshtein.Visible = false;
                btnDamerauLevenshtein.Visible = false;
                labelDist.Text = "Введите минимально допустимое совпадение";
                btnDice.Visible = true;
            }
            else
            {
                btnDice.Visible = false;
                btnBack.Visible = true;
                btnSoundex.Visible = true;
                btnGoToSoundex.Visible = false;
                labelDist.Visible = false;
                insertDistance.Visible = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnJaroWinkler.Visible = true;
            btnHamming.Visible = true;
            btnLevenshtein.Visible = true;
            btnDamerauLevenshtein.Visible = true;
            
            btnBack.Visible = false;
            btnSoundex.Visible = false;
            btnGoToSoundex.Visible = true;
            labelDist.Text = "Введите максимально допустимое расстояние поиска";
            labelDist.Visible = true;
            insertDistance.Visible = true;
        }

        private void btnDice_Click(object sender, EventArgs e)
        {
            clearAll();
           
            if ((rtbData.Text == "") || (txtInput.Text == "") || (insertDistance.Text == ""))
            {
                this.errorProviderD.SetError(btnDice, "Одно из полей пустое");
            }
            else
            {

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                List<string> allCloseWords = new List<string>();
                string checker = txtInput.Text.ToString();
                    string editLines = rtbData.Text.ToString();
                    string insertedDist = insertDistance.Text.ToString();
                double minDist = 0.0;
                int k = 0;
                string leftNum = "";
                double left = 0.0;
                if (insertedDist.IndexOf('.') != -1)
                {
                    while (insertedDist[k] != '.')
                    {
                        leftNum += insertedDist[k];
                        k++;
                    }
                    left = Convert.ToDouble(leftNum);
                    k++;
                }
                
                double u = 1.0;
                string rightNum = "";
                while (k < insertedDist.Length)
                {
                    rightNum += insertedDist[k];
                    u *= 10;
                    k++;
                }
                
                double right = Convert.ToDouble(rightNum);
                right = right / u;
                minDist = left + right;
                    string checkFromRTF = "";
                    int i = 0;
                    string closestWord = "";
                    double maxDist = 0.0;
                    int length = editLines.Length;
                    while (i < length)
                    {
                        checkFromRTF = "";
                        while ((i < length) && (!checkIfNeededChar(editLines[i])))
                            i++;
                        while ((i < length) && (checkIfNeededChar(editLines[i])))
                        {
                            checkFromRTF += editLines[i];
                            i++;
                        }
                        double checkDist = Metricas.GetDiceMatch(checker, checkFromRTF);
                    double checkDist1 = Metricas.GetDiceMatch(checker, checkFromRTF.ToLower());
                    if (checkDist1 == maxDist)
                    {
                        allCloseWords.Add(checkFromRTF);
                    }
                    else if (checkDist1 > maxDist)
                    {
                        allCloseWords.Clear();
                        allCloseWords.Add(checkFromRTF);
                        maxDist = checkDist1;
                        closestWord = checkFromRTF;
                    }

                    if (checkDist >= minDist)
                        {
                            int index;
                            if (checkDotOrComma(editLines[i - 1])) index = i - checkFromRTF.Length - 1;
                            else index = i - checkFromRTF.Length;
                            rtbData.Select(index, checkFromRTF.Length);
                            rtbData.SelectionColor = Color.Red;
                        }
                        

                    }
                if (closestWord == "")
                    lblMaybeYouSearched.Text = "Возможно вы искали: нет подходящих результатов";
                else lblMaybeYouSearched.Text = "Возможно вы искали: " + closestWord + "?";
                lblMaybeYouSearched.Text = maxDist.ToString();
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds);
                txtElapsedTime.Text = elapsedTime;
                int cnt = 0;
                foreach (string str in allCloseWords)
                {
                    if (str == closestWord) cnt++;
                }
                if (allCloseWords.Count == 0)
                    txtPercent.Text = Convert.ToString(0);
                else txtPercent.Text = Convert.ToString((Convert.ToDouble(cnt) / Convert.ToDouble(allCloseWords.Count)) * 100.0);
            }
        }

        private void btnSoundex_Click(object sender, EventArgs e)
        {
            clearAll();
           
            if ((rtbData.Text == "") || (txtInput.Text == ""))
            {
                this.errorProviderS.SetError(btnSoundex, "Одно из полей пустое");
            }
            else
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                List<string> allCloseWords = new List<string>();
                string checker = txtInput.Text.ToString();
                string editLines = rtbData.Text.ToString();
                string closestWord = "";
                string checkFromRTF = "";
                int i = 0;
                int length = editLines.Length;
                    while (i < length)
                    {
                        checkFromRTF = "";
                        while ((i < length) && (!checkIfNeededChar(editLines[i])))
                            i++;
                        while ((i < length) && (checkIfNeededChar(editLines[i])))
                        {
                            checkFromRTF += editLines[i];
                            i++;
                        }
                        int resSound = Soundex.checkIfSame(checkFromRTF, checker);
                        if (resSound == 1)
                        {
                        allCloseWords.Add(checkFromRTF);
                            int index;
                            if (checkDotOrComma(editLines[i - 1])) index = i - checkFromRTF.Length - 1;
                            else index = i - checkFromRTF.Length;
                            closestWord = checkFromRTF;
                            rtbData.Select(index, checkFromRTF.Length);
                            rtbData.SelectionColor = Color.Red;
                        }
                        lblMaybeYouSearched.Text = "Возможно вы искали не выполняется для этого алгоритма";
                  
                }
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds);
                    txtElapsedTime.Text = elapsedTime;
                int cnt = 0;
                foreach (string str in allCloseWords)
                {
                    if (str == closestWord) cnt++;
                }
                if (allCloseWords.Count == 0)
                    txtPercent.Text = Convert.ToString(0);
                else txtPercent.Text = Convert.ToString((Convert.ToDouble(cnt) / Convert.ToDouble(allCloseWords.Count)) * 100.0);
            }
        }
    }
}
