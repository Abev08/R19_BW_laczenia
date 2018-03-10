# R19 Blood Wars Łączenia
   
Aplikacja wspomagająca łączenie przedmiotów w grze Blood Wars (www.bloodwars.interia.pl).  
Listy przedmiotów przystosowano do serwera R19.  
   
Wewnątrz archiwum R19_BW_laczenia.zip znajduje się wykonywalna wersja programu ([.exe](https://github.com/Abev08/R19_BW_laczenia/raw/master/R19_BW_laczenia.zip) - wystarczy to pobrać).  
Aktualna wersja programu: 2.7.1. Wersję używanego programu można sprawdzić najeżdżając myszką na "by Abev".  
   
   
## Funkcje programu
 - Możliwość łączenia każdego dostępnego w grze typu przedmiotu,
 - Możliwość łączenia przedmiotów z prefiksami i sufiksami lub łączenia samych prefiksów / baz / sufiksów,
 - Możliwość cofnięcia przeprowadzonych połączeń,
 - Trzy elementowy schowek do przechowywania przedmiotów w trakcie sesji łączenia,
 - Możliwość wyświetlenia tabeli łączeń prefiksów / baz / sufiksów każdego typu przedmiotu,
 - Tabela łączeń:
   - Możliwość wyświetlania jednocześnie wielu tabeli łączeń w formie zakładek,
   - Możliwość zamknięcia wybranej zakładki tabeli łączeń klikając prawym przyciskiem lub środkowym przyciskiem (kółkiem) myszy na jej zakładce,
   - Możliwość zmiany rozmiaru czcionki wyświetlanych elementów tabeli łączeń,
   - Podświetlanie wiersza i kolumny wybranego elementu tabeli łączeń,
 - Analizator raportów łączenia umożliwiający wyświetlenie podsumowania przeprowadzonych ulepszeń,
 - Analizator łączeń wyszukujący możliwe połączenia z listy przedmiotów:
   - Możliwość załadowania listy przedmiotów z tekstu lub poprzez edytor załadowanych przedmiotów,
   - Możliwość łączenia każdego dostępnego w grze typu przedmiotu,
   - Brak ograniczenia ilości łączonych przedmiotów,
   - Możliwość ustawienia maksymalnej ilości wyszukiwanych połączeń,
   - Możliwość filtrowania przeanalizowanych połączeń,
   - Możliwość wyświetlenia historii połączeń,
   - Możliwość sortowania załadowanych przedmiotów według: jakość prefiksu -> jakość bazy -> jakość sufiksu,
   - Sortowanie wyszukanych wyników połączeń według: jakość prefiksu -> jakość bazy -> jakość sufiksu -> ilość połączeń,
   - Domyślnie wyszukiwane połączenia: ((A+B) + C) + D + itd.,
   - Możliwość włączenia wyszukiwania dodatkowych połączeń: (A+B) + (C+D) + (E+F) + itd.,
   - Możliwość włączenia wyszukiwania połączeń mieszanych: (A+B) + C + (D+E) + F + itd. (odpowiednio (A+B) + (C+D) + E + itd.),
   - Analizator łączeń do działania wykorzystuje nowy wątek - możliwe jest przerwanie działania po wciśnięciu klawisza Esc,
   - Możliwość wyboru szukanego prefiksu / bazy / sufiksu (wyświetlone zostaną tylko wyniki łączeń pasujące do szukanego przedmiotu).
 - Menu prawego przycisku myszy umożliwiające:
   - Wklejenie tekstu do okienka (dostępne wyłącznie w analizatorze raportów i analizatorze łączeń),
   - Kopiowanie zaznaczonego tekstu,
   - Kopiowanie całego wyświetlanego tekstu,
   - Zapisywanie wyświetlanego tekstu do pliku,
   - Czyszczenie przebiegu łączeń / raportu w analizatorze raportów,
   - Wysłanie zaznaczonego przedmiotu do schowka programowego (nie dostępne w analizatorze raportów i analizatorze łączeń).
 - Podczas uruchamiania program informuje o dostępności nowszych wersji.   
   
   
   
## Screenshoty
Ręczne łączenie.
![Ręczne łączenie](Screenshots/Ręczne_łączenie.png?raw=true "Ręczne łączenie")   
   
   
Tabela łączeń.
![Tabela łączeń](Screenshots/Tabela_łączeń.png?raw=true "Tabela łączeń")   
   
   
Analizator raportów.
![Analizator raportów](Screenshots/Analizator_raportu.png?raw=true "Analizator raportów")   
   
   
Analizator łączeń.
![Analizator łączeń](Screenshots/Analizator_łączeń.png?raw=true "Analizator łączeń") 
   
   
   
--------------------------
   
   
Do poprawnego działania aplikacja wymaga zainstalowanego środowiska .NET Framework 4.5 lub nowszej wersji.  
[Changelog](Changelog.txt). Proszę zgłaszać wszelkie znalezione błędy / sugestie dotyczące programu :)  