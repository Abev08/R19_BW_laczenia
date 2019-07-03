using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narzędzie_Blood_Wars___R19
{
    public class ItemType
    {
        public ItemType(string type)
        {
            // Listy prefiksów, baz i sufiksów przedmiotów w uporządkowanej kolejności
            switch (type)
            {
                case "Hełm":
                    pref = new List<string>() { "", "Utwardzany", "Wzmocniony", "Pomocny", "Ozdobny", "Elegancki", "Rogaty", "Złośliwy", "Leniwy", "Śmiercionośny", "Bojowy", "Magnetyczny", "Krwawy", "Kunsztowny", "Kuloodporny", "Szamański", "Tygrysi", "Szturmowy", "Runiczny", "Rytualny" };
                    baza = new List<string>() { "", "Czapka", "Kask", "Hełm", "Maska", "Obręcz", "Kominiarka", "Kapelusz", "Opaska", "Bandana", "Korona" };
                    suf = new List<string>() { "", "Podróżnika", "Przezorności", "Wytrzymałości", "Pasterza", "Narkomana", "Ochrony", "Zmysłów", "Wieszcza", "Kary", "Gladiatora", "Krwi", "Skorupy żółwia", "Słońca", "Adrenaliny", "Prekognicji", "Smoczej Łuski", "Mocy", "Magii" };
                    break;

                case "Zbroja":
                    pref = new List<string>() { "", "Wzmocniony", "Ćwiekowany", "Władczy", "Lekki", "Łuskowy", "Bojowy", "Płytowy", "Giętki", "Krwawy", "Łowiecki", "Szamański", "Kuloodporny", "Tygrysi", "Elfi", "Runiczny", "Śmiercionośny" };
                    baza = new List<string>() { "", "Koszulka", "Kurtka", "Marynarka", "Kamizelka", "Gorset", "Peleryna", "Smoking", "Kolczuga", "Zbroja warstwowa", "Pełna zbroja" };
                    suf = new List<string>() { "", "Adepta", "Strażnika", "Złodzieja", "Siłacza", "Narkomana", "Szermierza", "Zabójcy", "Gwardzisty", "Kobry", "Skorupy żółwia", "Uników", "Grabieżcy", "Mistrza", "Adrenaliny", "Centuriona", "Odporności", "Kaliguli", "Siewcy Śmierci", "Szybkości", "Orchidei" };
                    break;

                case "Spodnie":
                    pref = new List<string>() { "", "Krótkie", "Pikowane", "Lekkie", "Wzmocnione", "Aksamitne", "Ćwiekowane", "Kuloodporne", "Giętkie", "Kolcze", "Szamańskie", "Krwawe", "Elfie", "Tygrysie", "Pancerne", "Runiczne", "Kompozytowe", "Śmiercionośne" };
                    baza = new List<string>() { "", "Szorty", "Spodnie", "Spódnica", "Kilt" };
                    suf = new List<string>() { "", "Rzezimieszka", "Przemytnika", "Narkomana", "Siłacza", "Cichych Ruchów", "Uników", "Skrytości", "Słońca", "Handlarza Bronią", "Pasterza", "Łowcy Cieni", "Węża", "Inków", "Tropiciela", "Nocy" };
                    break;

                case "Pierścień":
                    pref = new List<string>() { "", "Miedziany", "Srebrny", "Szmaragdowy", "Złoty", "Platynowy", "Rubinowy", "Dystyngowany", "Przebiegły", "Kardynalski", "Elastyczny", "Nekromancki", "Gwiezdny", "Niedźwiedzi", "Twardy", "Zwierzęcy", "Tańczący", "Archaiczny", "Hipnotyczny", "Diamentowy", "Mściwy", "Spaczony", "Plastikowy", "Zdradziecki", "Tytanowy", "Słoneczny", "Pajęczy", "Jastrzębi", "Czarny" };
                    baza = new List<string>() { "", "Pierścień", "Sygnet", "Bransoleta" };
                    suf = new List<string>() { "", "Występku", "Urody", "Władzy", "Siły", "Geniuszu", "Mądrości", "Twardej Skóry", "Wilkołaka", "Sztuki", "Celności", "Młodości", "Lisa", "Szczęścia", "Krwi", "Nietoperza", "Koncentracji", "Lewitacji", "Przebiegłości", "Szaleńca", "Łatwości" };
                    break;

                case "Amulet":
                    pref = new List<string>() { "", "Miedziany", "Srebrny", "Szmaragdowy", "Złoty", "Platynowy", "Rubinowy", "Dystyngowany", "Przebiegły", "Kardynalski", "Elastyczny", "Nekromancki", "Gwiezdny", "Niedźwiedzi", "Twardy", "Diamentowy", "Mściwy", "Archaiczny", "Tańczący", "Hipnotyczny", "Zwierzęcy", "Spaczony", "Plastikowy", "Zdradziecki", "Tytanowy", "Słoneczny", "Pajęczy", "Jastrzębi", "Czarny" };
                    baza = new List<string>() { "", "Naszyjnik", "Amulet", "Łańcuch", "Apaszka", "Krawat" };
                    suf = new List<string>() { "", "Występku", "Urody", "Władzy", "Geniuszu", "Siły", "Mądrości", "Twardej Skóry", "Pielgrzyma", "Wilkołaka", "Celności", "Sztuki", "Młodości", "Szczęścia", "Krwi", "Zdolności", "Koncentracji", "Lewitacji", "Przebiegłości", "Szaleńca", "Łatwości" };
                    break;

                case "Biała 1h":
                    pref = new List<string>() { "", "Ostry", "Zębaty", "Kościany", "Wzmacniający", "Kryształowy", "Mistyczny", "Lekki", "Okrutny", "Przyjacielski", "Kąsający", "Opiekuńczy", "Świecący", "Jadowity", "Zabójczy", "Zatruty", "Przeklęty", "Zwinny", "Antyczny", "Szybki", "Demoniczny" };
                    baza = new List<string>() { "", "Pałka", "Nóż", "Sztylet", "Kastet", "Miecz", "Rapier", "Kama", "Topór", "Wakizashi", "Pięść Niebios" };
                    suf = new List<string>() { "", "Dowódcy", "Sekty", "Bólu", "Władzy", "Zwinności", "Mocy", "Zarazy", "Odwagi", "Trafienia", "Przodków", "Zdobywcy", "Kontuzji", "Męstwa", "Precyzji", "Krwi", "Zemsty", "Podkowy", "Drakuli", "Biegłości", "Klanu", "Imperatora", "Samobójcy" };
                    break;

                case "Biała 2h":
                    pref = new List<string>() { "", "Kosztowny", "Ostry", "Kryształowy", "Zębaty", "Szeroki", "Okrutny", "Mistyczny", "Wzmacniający", "Kąsający", "Lekki", "Ciężki", "Zatruty", "Napromieniowany", "Świecący", "Opiekuńczy", "Jadowity", "Zabójczy", "Przeklęty", "Zwinny", "Antyczny", "Demoniczny" };
                    baza = new List<string>() { "", "Maczuga", "Łom", "Miecz dwuręczny", "Topór dwuręczny", "Korbacz", "Kosa", "Pika", "Halabarda", "Katana", "Piła łańcuchowa" };
                    suf = new List<string>() { "", "Zdrady", "Podstępu", "Bólu", "Hazardzisty", "Ołowiu", "Mocy", "Inkwizytora", "Krwiopijcy", "Zdobywcy", "Władzy", "Zemsty", "Zarazy", "Podkowy", "Autokraty", "Krwi", "Bazyliszka", "Samobójcy", "Drakuli" };
                    break;

                case "Palna 1h":
                    pref = new List<string>() { "" };
                    baza = new List<string>() { "", "Glock", "Beretta", "Uzi", "Magnum", "Desert Eagle", "Mp5k", "Skorpion" };
                    suf = new List<string>() { "" };
                    break;

                case "Palna 2h":
                    pref = new List<string>() { "" };
                    baza = new List<string>() { "", "Karabin myśliwski", "Półautomat snajperski", "Karabin snajperski", "AK-47", "Fn-Fal", "Strzelba", "Miotacz płomieni" };
                    suf = new List<string>() { "" };
                    break;

                case "Dystansowa":
                    pref = new List<string>() { "" };
                    baza = new List<string>() { "", "Krótki łuk", "Łuk", "Shuriken", "Długi łuk", "Kusza", "Nóż do rzucania", "Łuk refleksyjny", "Oszczep", "Pilum", "Toporek do rzucania", "Ciężka kusza" };
                    suf = new List<string>() { "", "Dalekiego zasięgu", "Doskonałości", "Precyzji", "Zemsty", "Reakcji", "Driady", "Szybkostrzelności", "Wilka" };
                    break;
            }

            pref.TrimExcess();
            baza.TrimExcess();
            suf.TrimExcess();
        }

        public List<string> pref;
        public List<string> baza;
        public List<string> suf;

        // Dostępne typy przedmiotów
        public static List<string> Items = new List<string>() { "Hełm", "Zbroja", "Spodnie", "Pierścień", "Amulet", "Biała 1h", "Biała 2h", "Palna 1h", "Palna 2h", "Dystansowa" };
    }
}