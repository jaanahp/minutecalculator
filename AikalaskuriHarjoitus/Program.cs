using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AikalaskuriHarjoitus
{
    class Program
    {
        //Tee konsolisovellus, joka kysyy käyttäjältä kaksi päivämäärää kellonaikoineen ja laskee niiden erotuksen minuuteissa.
        //Tulos näytetään konsolilla ja rutiini laitetaan silmukan sisään, jotta käyttäjän on helppo syöttää uudet arvot ja laskea uusi erotus.
        //Muutettu laskenta-rutiini omaksi alirutiinikseen
        //Lisätty while-silmukka ja sinne laskennan kutsu sekä try-catch virheen käsittely laskentarutiiniin
        //Lisätty pyydetylle päivämäärälle formaattimääritys, joka vaatii tietynlaisen syötön ja sen myötä muutettu DateTime.Parse DateTime.ParseExacticsi.
        static void Main(string[] args) //Pääohjelma
        {
            Laskenta(); //kutsuu laskenta-alirutiinia, joka käydään läpi kerran ennen siirtymistä while-silmukkaan
            Boolean jatka = true; //boolean-muuttuja jatka arvo asetetaan tässä trueksi

            while (jatka == true) //while-silmukka pyörii, niin kauan kun jatka-muuttujan arvo on true
            {
                Console.WriteLine("Haluatko suorittaa laskennan uudelleen? K=Kylläl/E=Ei"); //kysytään käyttäjältä, haluaako hän jatkaa
                if (Console.ReadLine().ToUpper() == "K") //jos käyttäjän syöttämä tieto konsolilta luettuna on isoksi muutettuna "K"
                {
                    Laskenta(); //kutsutaan taas Laskenta-alirutiinia
                    jatka = true; //ja asetetaan jatka-muuttujan arvoksi taas true
                } else //jos käyttäjän syöttämä arvo on jotakin muuta kuin "K"
                {
                    jatka = false; //asetetaan jatka-muuttujan arvoksi false, silmukka päättyy ja ohjelman suoritus päättyy
                } 
            }
        }

        private static void Laskenta() //Laskenta()-alirutiini, jota kutsutaan pääohjelman while-silmukassa
        {
            string paiva1, paiva2;
            Double paivienErotus = 0;
            string pvmformaatti = "dd.MM.yyyy HH:mm.ss"; //lisätty formaatti sille, missä muodossa tieto tulee käyttäjältä jolloin ohjelma hyväksyy tiedot vain, jos niissä on myös kellonaika
            CultureInfo kulttuuri = CultureInfo.InvariantCulture;

            Console.WriteLine("Anna ensimmäinen päivämäärä ja kellonaika muodossa dd.MM.yyyy HH:mm.ss"); //kysytään käyttäjältä päivämäärä kellonaikoineen
            paiva1 = Console.ReadLine(); //asetetaan konsolilta luettu arvo paiva1 muuttujaan
            try //ohjelma yrittää tehdä tätä:
            {
                DateTime paiva1DT = DateTime.ParseExact(paiva1, pvmformaatti, kulttuuri); //muunnetaan paiva1-muuttuja ParseExactilla DateTime-tyyppiseksi string-tyyppisestä
                Console.WriteLine("Anna toinen päivämäärä ja kellonaika muodossa dd.MM.yyyy HH:mm.ss"); 
                paiva2 = Console.ReadLine();
                DateTime paiva2DT = DateTime.ParseExact(paiva2, pvmformaatti, kulttuuri); //Muunnetaan paiva1 ParseExactilla DateTime-tyyppiseksi. ParseExact hyödyntää parametrinä formaattitietoa ja CultureInfoa.
                paivienErotus = paiva1DT.Subtract(paiva2DT).TotalMinutes; //tallennetaan paiva1DT:n ja paiva2DT:n erotus double-tyyppiseen muuttujaan paivienErotus.
                Console.WriteLine("Päivämäärien erotus on {0} minuuttia.", paivienErotus.ToString()); //tulostetaan laskettu erotus konsolille
            }
            catch (Exception) //jos yllä oleva ei onnistu (eli Parse DateTimeksi), siirrytään tähän:
            {
                Console.WriteLine("Tarkista syöttämäsi arvo");
            }
        }
    }
}
