Jest to prosta symulacja gry dla dwóch osób, w której gracz
posiada zdefiniowaną liczbę statków, oraz układa je w sposób losowy.
Gracz po wybraniu miejsc startowych, sprawdza, czy nie kolidują one z planszą,
oraz z innymi statkami.
Jeśli, kolidują, to wybiera inne miejsce startowe.
Po wybraniu, grę rozpoczyna gracz nr 1(jak to zwykle bywa).

W przypadku domyślnym, mamy 17 pól, gdzie taki gracz może trafić.
Za każde trafienie, gracz otrzymuje komunikat, że udało mu się
trafić przeciwnika, oraz wyświetla się mu stosowny komunikat, który jest obowiązujący,
tylko w tedy, kiedy na jego ekranie, widzi komunikat: "Czeka na swoją kolej".
Zmienia się także, na ekranie liczba pól "jeszcze do trafienia".

Gra toczy się, do momentu, aż jeden z graczy
trafi 17/17 statków, w tedy gra kończy się wystawieniem stosownego komunikatu.

Stworzyłem, tylko możliwość, "ustawiania" statków, w pozycji poziomej
gdyż dla mojego projektu, pionowo, tworzy się analogicznie.


Legenda
{
	Gra 
	{
		Niebieskie pole - puste,
		Czarne - zajęte(przez statek),
		Czerwone(podczas gry) - zaznaczenie trafienia.
	}
	Klasy
	{
		Models = folder, zawiera 2 klasy, które posiadają wymiary statków(ShipModels), oraz planszy(StartModel),

		AllDatas = jest to klasa, w której przechowuję większość użytych danych,

		AmountOfShips = klasa, która liczy ilość statków(dynamicznie),

		BattleBegin = klasa, która sprawdza, czy gracz "trafił" w pole, na którym jest statek, a potem sprawdza,
		czy już takie uderzenie, nie miało miejsca.

		CreateShips = tworzę statki,

		GameBegin = metoda końcowa, która rozstzyga, który z graczy wygrał,

		IsEnoughSpace = sprawdzam, czy potencjalny statek, "nie wychodzi", poza planszę,

		IsShipPlacedCorr = sprawdzam, czy potencjalny statek, nie koliduje z utworzonymi juz statkami,

		MainWindow = strona startowa,

		Options = klasa z opcjami nt gry,

		Player1 = mapę unikalną mapę gracza, oraz symuluje jego ruchy (czasowo również),

		Player2 - -||-

		PlayerChoose = symuluje wybieranie pola,

		RandomPlace = zwraca 2 cyfry, z przedziału (0, 9)mapę

		RandomPlaces = losuje (w zależności od tego, ile jest statków) liczbę początkowych unikalnych pól.
	}
}
