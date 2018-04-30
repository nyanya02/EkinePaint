using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace EkinePaint
{
    public partial class Form1 : Form
    {

        private Pen pen;
        private Color penColor = Color.Blue;
        private int penWidth = 1;

        private Point prevLocation;

        private bool canDraw = false;

        private Bitmap bitmap;
        private Graphics g;

        private List<string> imageName = new List<string>();
        private int curNum = 0;
        private string curFileDirectory = "";

        private float imageAlpha = 0;//0-1
        private const float alphaMax = 255;
        private Bitmap transparentBitmap;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            writeArea.BackColor = Color.Transparent;

            pen = new Pen(penColor, penWidth);

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            ChangeImageAlpha(imageAlpha);

            label1.Text = "0";

            writeArea.Parent = picTransparent;
            picTransparent.Parent = imageBox;

            InitializeBitmap();
        }

        private void writeArea_MouseDown(object sender, MouseEventArgs e)
        {
            canDraw = true;
            prevLocation = e.Location;
            writeArea_MouseMove(sender, e);
        }

        private void writeArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (!canDraw)
                return;

            g.DrawLine(pen, prevLocation, e.Location);

            prevLocation = e.Location;

            writeArea.Image = bitmap;
        }

        private void writeArea_MouseUp(object sender, MouseEventArgs e)
        {
            canDraw = false;

            writeArea.Image = bitmap;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.O)//画像表示
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "イメージの形式(*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif";

                if (open.ShowDialog() != DialogResult.OK)
                    return;

                string curImage = open.FileName;
                curFileDirectory = Path.GetDirectoryName(open.FileName);

                string[] fileAll = Shuffle.ReadImage(curFileDirectory);

                ShuffleImage(fileAll, curImage);

            }
            else if (e.KeyCode == Keys.Up)//透明度下げる
            {
                imageAlpha -= 0.1f;
                if (imageAlpha < 0)
                    imageAlpha = 0;

                ChangeImageAlpha(imageAlpha);
            }
            else if (e.KeyCode == Keys.Down)//透明度上げる
            {
                imageAlpha += 0.1f;
                if (imageAlpha > 1f)
                    imageAlpha = 1;

                ChangeImageAlpha(imageAlpha);
            }else if(e.KeyCode == Keys.Back)//描いたものの削除
            {
                InitializeBitmap();
            }else if(e.KeyCode == Keys.Right)//画像を変更（右へ）
            {
                curNum++;
                if (curNum > imageName.Count - 1)
                    curNum = 0;
 
                ChangeImage(curNum);
            }
            else if (e.KeyCode == Keys.Left)//画像を変更（左へ）
            {
                curNum--;
                if (curNum < 0)
                    curNum = imageName.Count - 1;

                ChangeImage(curNum);
            }else if(e.KeyCode == Keys.C)//色を変える
            {
                ColorDialog colorDialog = new ColorDialog();

                if (colorDialog.ShowDialog() != DialogResult.OK)
                    return;

                penColor = colorDialog.Color;

                pen = new Pen(penColor, penWidth);
            }else if(e.KeyCode == Keys.Escape)//アプリケーションの終了
            {
                this.Close();
            }else if(e.KeyCode == Keys.V)//画像読み込み数の表示・非表示
            {
                label1.Visible = !label1.Visible;
            }
            else if (e.KeyCode == Keys.R)//画像の再読み込み＆並び替え
            {

                if(curFileDirectory == "")
                {
                    return;
                }

                string[] fileAll = Shuffle.ReadImage(curFileDirectory);

                ShuffleImage(fileAll, imageName[curNum]);

            }
            else if(e.KeyCode == Keys.Delete)//表示画像の削除
            {

                //削除する場合は次の画像を表示してから削除すること
                if (imageName.Count <= 0)
                    return;

                if (MessageBox.Show("表示している画像を消しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                bool last = false;

                var oldImage = imageBox.Image;

                if (imageName.Count > 1)
                {

                    if (curNum != imageName.Count - 1)
                    {
                        curNum++;
                    }
                    else//削除したい画像が最後の場合は特別な処理が必要
                    {
                        curNum--;
                        last = true;
                    }

                    ChangeImage(curNum);

                    if (last)
                        curNum += 2;
                }
                else//読み込んだ画像が一枚だけの場合
                {
                    curNum = 1;
                    last = true;
                }

                if (imageName.Count == 1)
                {
                    imageBox.Image = null;
                    oldImage.Dispose();
                }

                FileSystem.DeleteFile(imageName[curNum - 1], UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

                imageName.RemoveAt(curNum - 1);

                curNum--;
                if (curNum < 0)
                {
                    curNum = 0;
                }

                if (last)
                    curNum--;

                label1.Text = imageName.Count.ToString();
            }else if(e.KeyCode == Keys.N)//別機能　読み込んだ画像と同じフォルダ内の画像の名前を変更する
            {
                Rename renameForm = new Rename();
                renameForm.Show();
            }
        }

        private void InitializeBitmap()
        {
            bitmap = new Bitmap(writeArea.Width, writeArea.Height);
            g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            writeArea.Image = bitmap;
        }

        private void ChangeImageAlpha(float imageAlpha)
        {
            int value = (int)(alphaMax * imageAlpha);

            //半透明レイヤー作成
            Brush b = new SolidBrush(Color.FromArgb(value, Color.White));
            transparentBitmap = new Bitmap(imageBox.Width, imageBox.Height);
            Graphics g1 = Graphics.FromImage(transparentBitmap);
            g1.FillRectangle(b, 0, 0, transparentBitmap.Width, transparentBitmap.Height);
            g1.Dispose();
            b.Dispose();
            picTransparent.BackColor = Color.Transparent;
            picTransparent.Image = transparentBitmap;
        }

        private void ChangeImage(int num)
        {
            if (imageName.Count <= 0)
                return;

            var oldImage = imageBox.Image;

            curNum = num;

            label1.Text = imageName.Count.ToString();

            imageBox.Image = Image.FromFile(imageName[curNum]);

            oldImage.Dispose();

            InitializeBitmap();

        }

        private void DisplayImage(string[] fileAll, string curImage)
        {

            curNum = 0;

            imageName.Clear();
            imageName.AddRange(fileAll);
            imageName.Remove(curImage);
            imageName.Insert(0, curImage);

            imageBox.Image = Image.FromFile(imageName[curNum]);

            label1.Text = imageName.Count.ToString();
        }

        private void ShuffleImage(string[] fileAll, string curImage)
        {

            fileAll = Shuffle.ShuffleImage(fileAll);

            DisplayImage(fileAll, curImage);

        }
    }
}
