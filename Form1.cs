

/* Algoritmit 2 - kurssin harjoitustyö
 * Alkulukuanalysointi kahdella eri algoritmilla
 * Copyright Tero Niemi 2012
 */ 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;

namespace AlkulukuTesti2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tarkista_Click(object sender, EventArgs e)
        {
            try
            {
                tarkista.Enabled = false;
               

                // asetetaan biginteger muuttuja p:ksi luku, jota halutaan tutkia
                // käytetään bigintegeriä, että saadaan tutkittua todella suuria lukuja
                
                BigInteger p = BigInteger.Parse(tutkittavaluku.Text);
                
               

                // testauskertojen määrä määräytyy käyttäjän tekemän valinnan mukaan
                int amax = 0;
                if (testaustarkkuus.SelectedIndex == -1) MessageBox.Show("Valitse testaustarkkuus!");
                if (testaustarkkuus.SelectedIndex == 0) amax = 3;
                if (testaustarkkuus.SelectedIndex == 1) amax = 100;
                if (testaustarkkuus.SelectedIndex == 2) amax = 1000;
                if (testaustarkkuus.SelectedIndex == 3) amax = 10000;

                // tutkitaan ettei testaustarkkuus ole suurempi kuin tutkittava luku
                if (p <= amax)
                {
                    MessageBox.Show("Tutkittava luku on pienempi tai yhtäsuuri kuin testaustarkkuus!\nPienennä testaustarkkuutta tai vaihda tutkittavaa lukua");
                }
                
                
                else if (testaustarkkuus.SelectedIndex != -1)
                {
      


                    // luodaan ajon aikana tarvittavat muuttujat laskentaa varten
                    // käytetän BigInteger luokan muuttujia, jotta voidaan käsitellä todella suuria lukuja
                    BigInteger laskentaFermat = new BigInteger();
                    BigInteger laskentaSolovay = new BigInteger();
                    BigInteger Solovay_a_p = new BigInteger();

                    // luodaan bool muuttujat molemmille testeille, jotka kertovat onko tutkittava luku
                    // alkuluku kyseisen testin mukaan. Alustetaan ne trueksi. Kun looppi pyörii, niin
                    // näitä muuttujia muutetaan vain ja ainoastaan jos havaitaan, että luku ei ole 
                    // alkuluku. 
                    bool alkulukuFermat = true;
                    bool alkulukuSolovay = true;

                    // käynnistetään looppi, joka suorittaa testauksen molemmilla algoritmeilla
                    // a:ta vaihdetaan niin monta kertaa kuin käyttäjä on valinnut
                    for (int a = 1; a < amax; a++)
                    {
                        // fermatin algoritmi 
                        // a^p-1 -1 = 1 (mod p)
                        laskentaFermat = (BigInteger.ModPow(a, (p - 1), p));

                        // jos tulos erisuuri kuin 1, luku ei ole alkuluku
                        if (laskentaFermat != 1)
                        {
                            // ei ole alkuluku, päivitetään tieto muuttujaan
                            alkulukuFermat = false;
                        }

                        // Solovay-Strassenin algoritmi 
                        // (a/p) = a^((p-1)/2) (mod p)
                        laskentaSolovay = (BigInteger.ModPow(a,((p-1)/2),p));

                        // jos tulos on joko 1 tai p-1 niin tällöin on kyseessä alkuluku
                        if (laskentaSolovay == 1 || laskentaSolovay == p - 1)
                        {
                            // luku on alkuluku, ei tehdä mitään muutoksia
                        }
                        else
                        {
                            alkulukuSolovay = false;
                        }


                    }


                    // tarkistetaan Fermatin algoritmin tulokset
                    // päivitetään tieto tuloksiin
                    if (alkulukuFermat)
                    {
                        tulosFermat.Text = "Alkuluku";
                        tulosFermat.ForeColor = Color.Green;
                    }

                    else
                    {
                        tulosFermat.Text = "Ei alkuluku";
                        tulosFermat.ForeColor = Color.Red;
                    }


                    // tarkistetaan Solovay Strassenin tulokset
                    // päivitetään tieto tuloksiin
                    if (alkulukuSolovay)
                    {
                        tulosSolovay.Text = "Alkuluku";
                        tulosSolovay.ForeColor = Color.Green;
                    }

                    else
                    {
                        tulosSolovay.Text = "Ei alkuluku";
                        tulosSolovay.ForeColor = Color.Red;
                    }

                    tarkista.Enabled = true;
                    

                }
            }
            catch
            {
                // virheidenkäsittely, mikäli luvuksi on syötetty jotain muuta kuin luku (esim. tekstiä)
                MessageBox.Show("Virhe! Tarkista syöttökentät!");
                tarkista.Enabled = true;
                
            }

        }

       

       
    }
}
