using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Narzędzie_Blood_Wars___R19
{
    class UpgradeReportAnalyzer
    {
        public static Tuple<string[], int[]> Analyze(string input)
        {
            /// Funkcja do analizy raportu łączenia
            // Zmienne do przechowywania całkowitej ilości ulepszeń i ilości udanych ulepszeń
            int zw0zw1 = 0, zw0zw1c = 0;
            int zw1zw2 = 0, zw1zw2c = 0;
            int zw2zw3 = 0, zw2zw3c = 0;
            int zw3zw4 = 0, zw3zw4c = 0;
            int zw4zw5 = 0, zw4zw5c = 0;
            int zw5db0 = 0, zw5db0c = 0;
            int db0db1 = 0, db0db1c = 0;
            int db1db2 = 0, db1db2c = 0;
            int db2db3 = 0, db2db3c = 0;
            int db3db4 = 0, db3db4c = 0;
            int db4db5 = 0, db4db5c = 0;
            int db5dsk0 = 0, db5dsk0c = 0;
            int dsk0dsk1 = 0, dsk0dsk1c = 0;
            int dsk1dsk2 = 0, dsk1dsk2c = 0;
            int dsk2dsk3 = 0, dsk2dsk3c = 0;
            int dsk3dsk4 = 0, dsk3dsk4c = 0;
            int dsk4dsk5 = 0, dsk4dsk5c = 0;

            // Podziel tekst na wiersze
            string[] ulepszenia = input.Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
            int[] resultColor = new int[ulepszenia.Count()]; // 1 - ForestGreen, 2 - Red, 3 - Gray
            string[] resultString = new string[3];

            // W każdym wierszu spróbuj wyszukać odpowiedni ciąg znaków (odpowiednie słowa) i na ich podstawie zwiększ odpowiednie zmienne
            for (int i = 0; i < ulepszenia.Count(); i++)
            {
                if (ulepszenia[i].Contains("Ulepszono przedmiot"))
                {
                    resultColor[i] = 1; // ForestGreen

                    if (ulepszenia[i].Contains("Doskonał") & ulepszenia[i].Contains("Dobr"))
                    {
                        // ulepszenie dobry -> dsk
                        db5dsk0++;
                        db5dsk0c++;
                    }
                    else if (ulepszenia[i].Contains("Doskonał"))
                    {
                        // ulepszanie dsk -> dsk
                        if (ulepszenia[i].Contains("(+4)") & ulepszenia[i].Contains("(+5)"))
                        {
                            // Doskonały (+4) -> Doskonały (+5)
                            dsk4dsk5++;
                            dsk4dsk5c++;
                        }
                        else if (ulepszenia[i].Contains("(+3)") & ulepszenia[i].Contains("(+4)"))
                        {
                            // Doskonały (+3) -> Doskonały (+4)
                            dsk3dsk4++;
                            dsk3dsk4c++;
                        }
                        else if (ulepszenia[i].Contains("(+2)") & ulepszenia[i].Contains("(+3)"))
                        {
                            // Doskonały (+2) -> Doskonały (+3)
                            dsk2dsk3++;
                            dsk2dsk3c++;
                        }
                        else if (ulepszenia[i].Contains("(+1)") & ulepszenia[i].Contains("(+2)"))
                        {
                            // Doskonały (+1) -> Doskonały (+2)
                            dsk1dsk2++;
                            dsk1dsk2c++;
                        }
                        else if (ulepszenia[i].Contains("(+1)") & !ulepszenia[i].Contains(("+2")))
                        {
                            // Doskonały -> Doskonały (+1)
                            dsk0dsk1++;
                            dsk0dsk1c++;
                        }
                    }
                    else if (ulepszenia[i].Contains("Dobr"))
                    {
                        // ulepszanie zwykły -> dobry i dobry -> dobry
                        if (ulepszenia[i].Contains("(+4)") & ulepszenia[i].Contains("(+5)"))
                        {
                            // Dobry (+4) -> Dobry (+5)
                            db4db5++;
                            db4db5c++;
                        }
                        else if (ulepszenia[i].Contains("(+3)") & ulepszenia[i].Contains("(+4)"))
                        {
                            // Dobry (+3) -> Dobry (+4)
                            db3db4++;
                            db3db4c++;
                        }
                        else if (ulepszenia[i].Contains("(+2)") & ulepszenia[i].Contains("(+3)"))
                        {
                            // Dobry (+2) -> Dobry (+3)
                            db2db3++;
                            db2db3c++;
                        }
                        else if (ulepszenia[i].Contains("(+1)") & ulepszenia[i].Contains("(+2)"))
                        {
                            // Dobry (+1) -> Dobry (+2)
                            db1db2++;
                            db1db2c++;
                        }
                        else if (ulepszenia[i].Contains("(+1)"))
                        {
                            // Dobry -> Dobry (+1)
                            db0db1++;
                            db0db1c++;
                        }
                        else if (ulepszenia[i].Contains("(+5)"))
                        {
                            // Zwykły (+5) -> Dobry
                            zw5db0++;
                            zw5db0c++;
                        }
                    }
                    else
                    {
                        // ulepszanie zwykły
                        if (ulepszenia[i].Contains("(+4)") & ulepszenia[i].Contains("(+5)"))
                        {
                            // Zwykły (+4) -> Zwykły (+5)
                            zw4zw5++;
                            zw4zw5c++;
                        }
                        else if (ulepszenia[i].Contains("(+3)") & ulepszenia[i].Contains("(+4)"))
                        {
                            // Zwykły (+3) -> Zwykły (+4)
                            zw3zw4++;
                            zw3zw4c++;
                        }
                        else if (ulepszenia[i].Contains("(+2)") & ulepszenia[i].Contains("(+3)"))
                        {
                            // Zwykły (+2) -> Zwykły (+3)
                            zw2zw3++;
                            zw2zw3c++;
                        }
                        else if (ulepszenia[i].Contains("(+1)") & ulepszenia[i].Contains("(+2)"))
                        {
                            // Zwykły (+1) -> Zwykły (+2)
                            zw1zw2++;
                            zw1zw2c++;
                        }
                        else if (ulepszenia[i].Contains("(+1)") & !ulepszenia[i].Contains("(+2)"))
                        {
                            // Zwykły -> Zwykły (+1)
                            zw0zw1++;
                            zw0zw1c++;
                        }
                    }
                }

                else if (ulepszenia[i].Contains("nie został ulepszony"))
                {
                    resultColor[i] = 2; // Red

                    if (ulepszenia[i].Contains("Doskonał"))
                    {
                        // Niepowodzenie ulepszenia przedmiotu doskonałego
                        if (ulepszenia[i].Contains("(+4)")) dsk4dsk5c++;
                        else if (ulepszenia[i].Contains("(+3)")) dsk3dsk4c++;
                        else if (ulepszenia[i].Contains("(+2)")) dsk2dsk3c++;
                        else if (ulepszenia[i].Contains("(+1)")) dsk1dsk2c++;
                        else if (!ulepszenia[i].Contains("(+1)")) dsk0dsk1c++;
                    }
                    else if (ulepszenia[i].Contains("Dobr"))
                    {
                        // Niepowodzenie ulepszenia przedmiotu dobrego
                        if (ulepszenia[i].Contains("(+5)")) db5dsk0c++;
                        else if (ulepszenia[i].Contains("(+4)")) db4db5c++;
                        else if (ulepszenia[i].Contains("(+3)")) db3db4c++;
                        else if (ulepszenia[i].Contains("(+2)")) db2db3c++;
                        else if (ulepszenia[i].Contains("(+1)")) db1db2c++;
                        else if (!ulepszenia[i].Contains("(+1)")) db0db1c++;
                    }
                    else if (true)
                    {
                        // Niepowodzenie ulepszenia przedmiotu zwykłego
                        if (ulepszenia[i].Contains("(+5)")) zw5db0c++;
                        else if (ulepszenia[i].Contains("(+4)")) zw4zw5c++;
                        else if (ulepszenia[i].Contains("(+3)")) zw3zw4c++;
                        else if (ulepszenia[i].Contains("(+2)")) zw2zw3c++;
                        else if (ulepszenia[i].Contains("(+1)")) zw1zw2c++;
                        else if (!ulepszenia[i].Contains("(+1)")) zw0zw1c++;
                    }
                }

                else resultColor[i] = 3; // Gray
            }

            // Wyświetl przeanalizowane ulepszenia
            resultString[0] = "Zwykły -> Zwykły (+1): " + zw0zw1.ToString() + "/" + zw0zw1c.ToString();
            if (zw0zw1c != 0) resultString[0] += ", " + Math.Round(((double)zw0zw1 / (double)zw0zw1c) * 100d, 2).ToString() + "%";
            resultString[0] += "\nZwykły (+1) -> Zwykły (+2): " + zw1zw2.ToString() + "/" + zw1zw2c.ToString();
            if (zw1zw2c != 0) resultString[0] += ", " + Math.Round(((double)zw1zw2 / (double)zw1zw2c) * 100d, 2).ToString() + "%";
            resultString[0] += "\nZwykły (+2) -> Zwykły (+3): " + zw2zw3.ToString() + "/" + zw2zw3c.ToString();
            if (zw2zw3c != 0) resultString[0] += ", " + Math.Round(((double)zw2zw3 / (double)zw2zw3c) * 100d, 2).ToString() + "%";
            resultString[0] += "\nZwykły (+3) -> Zwykły (+4): " + zw3zw4.ToString() + "/" + zw3zw4c.ToString();
            if (zw3zw4c != 0) resultString[0] += ", " + Math.Round(((double)zw3zw4 / (double)zw3zw4c) * 100d, 2).ToString() + "%";
            resultString[0] += "\nZwykły (+4) -> Zwykły (+5): " + zw4zw5.ToString() + "/" + zw4zw5c.ToString();
            if (zw4zw5c != 0) resultString[0] += ", " + Math.Round(((double)zw4zw5 / (double)zw4zw5c) * 100d, 2).ToString() + "%";
            resultString[0] += "\nZwykły (+5) -> Dobry: " + zw5db0.ToString() + "/" + zw5db0c.ToString();
            if (zw5db0c != 0) resultString[0] += ", " + Math.Round(((double)zw5db0 / (double)zw5db0c) * 100d, 2).ToString() + "%";

            resultString[1] = "\nDobry -> Dobry (+1): " + db0db1.ToString() + "/" + db0db1c.ToString();
            if (db0db1c != 0) resultString[1] += ", " + Math.Round(((double)db0db1 / (double)db0db1c) * 100d, 2).ToString() + "%";
            resultString[1] += "\nDobry (+1) -> Dobry (+2): " + db1db2.ToString() + "/" + db1db2c.ToString();
            if (db1db2c != 0) resultString[1] += ", " + Math.Round(((double)db1db2 / (double)db1db2c) * 100d, 2).ToString() + "%";
            resultString[1] += "\nDobry (+2) -> Dobry (+3): " + db2db3.ToString() + "/" + db2db3c.ToString();
            if (db2db3c != 0) resultString[1] += ", " + Math.Round(((double)db2db3 / (double)db2db3c) * 100d, 2).ToString() + "%";
            resultString[1] += "\nDobry (+3) -> Dobry (+4): " + db3db4.ToString() + "/" + db3db4c.ToString();
            if (db3db4c != 0) resultString[1] += ", " + Math.Round(((double)db3db4 / (double)db3db4c) * 100d, 2).ToString() + "%";
            resultString[1] += "\nDobry (+4) -> Dobry (+5): " + db4db5.ToString() + "/" + db4db5c.ToString();
            if (db4db5c != 0) resultString[1] += ", " + Math.Round(((double)db4db5 / (double)db4db5c) * 100d, 2).ToString() + "%";
            resultString[1] += "\nDobry (+5) -> Doskonały: " + db5dsk0.ToString() + "/" + db5dsk0c.ToString();
            if (db5dsk0c != 0) resultString[1] += ", " + Math.Round(((double)db5dsk0 / (double)db5dsk0c) * 100d, 2).ToString() + "%";

            resultString[2] = "\nDoskonały -> Doskonały (+1): " + dsk0dsk1.ToString() + "/" + dsk0dsk1c.ToString();
            if (dsk0dsk1c != 0) resultString[2] += ", " + Math.Round(((double)dsk0dsk1 / (double)dsk0dsk1c) * 100d, 2).ToString() + "%";
            resultString[2] += "\nDoskonały (+1) -> Doskonały (+2): " + dsk1dsk2.ToString() + "/" + dsk1dsk2c.ToString();
            if (dsk1dsk2c != 0) resultString[2] += ", " + Math.Round(((double)dsk1dsk2 / (double)dsk1dsk2c) * 100d, 2).ToString() + "%";
            resultString[2] += "\nDoskonały (+2) -> Doskonały (+3): " + dsk2dsk3.ToString() + "/" + dsk2dsk3c.ToString();
            if (dsk2dsk3c != 0) resultString[2] += ", " + Math.Round(((double)dsk2dsk3 / (double)dsk2dsk3c) * 100d, 2).ToString() + "%";
            resultString[2] += "\nDoskonały (+3) -> Doskonały (+4): " + dsk3dsk4.ToString() + "/" + dsk3dsk4c.ToString();
            if (dsk3dsk4c != 0) resultString[2] += ", " + Math.Round(((double)dsk3dsk4 / (double)dsk3dsk4c) * 100d, 2).ToString() + "%";
            resultString[2] += "\nDoskonały (+4) -> Doskonały (+5): " + dsk4dsk5.ToString() + "/" + dsk4dsk5c.ToString();
            if (dsk4dsk5c != 0) resultString[2] += ", " + Math.Round(((double)dsk4dsk5 / (double)dsk4dsk5c) * 100d, 2).ToString() + "%";

            return new Tuple<string[], int[]>( resultString, resultColor);
        }
    }
}