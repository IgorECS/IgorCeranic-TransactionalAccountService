Potrebno je napraviti servis za dohvatanje podataka o transakcijama tekučeg računa fizičkog lica.

 Servis treba da sadrži sledeće funkcionalnosti:

 
1)      Dohvatanje aktivnih tekućih računa prema unešenom matičnom broju lica
Treba dohvatati aktivne tekuće račune u odnosu na unešeni matični broj klijenta.
Aktivni tekući računi se nalaze u tabeli ITS i imaju u koloni STATUS vrijednost 2.
Treba dohvatii i stanje na računu, polje sostojba.


Napomena: Prilikom vraćanja traženih informacija o tekućim računima, broj računa mora da bude vraćen nazad u punom obliku, a isti se može dobiti pozivom funkcije brojracuna(‘530’,@BrojPartije).
Pomenuta funkcija se nalazi na bazi tako da je treba odatle pozvati.

2)      Dohvatanje aktivnih debitnih kartica vezanih za traženi tekući račun
Treba dohvatiti informacije o aktivnim debitnim karticama povezanim za traženi tekući račun kao što su: broj kartice, broj kartične partija, brand kartice, tip kartice, vrstu kartice, datum važenja, kao i matični broj vlasnika kartice tj. klijenta.

Navedeni podaci se mogu pronaći u tabelama CC_Cards (kolone: card_number, account, brand, type, kind, valid_thru, customer_id) i cc_Partije_Eksterne (kolona: exPartija).
Aktivne kartice su one kartice koje u koloni CC_Cards.card_status imaju status 1.

3)      Dohvatanje istorije potrošnje za sve transakcije
Treba dohvatiti spisak transakcija koje predstavljaju potrošnju sa svih aktivnih kartica koje su povezane za tekući račun klijenta.

Ove transakcije se mogu pronaći u tabeli PTS.

Kolona partija je partija tekućeg računa za koju se dohvataju transakcije.

Kolona DP definise da li je priliv ili odliv. Ako je 1 onda je priliv ako je -1 onda je odliv.

Pored toga transakcije treba da imaju datum, vreme (vrijeme transakcije), valiznos (iznos transakcije), opis, alfa1 (duzi opis), provizija, DP (duguje potrazuje)

Napomena: Treba dohvatiti top 100 transakcija.


4)      Dohvatanje aktivnih rezervacija za sve kartice klijenta
Potrebno je dohvatiti informacije o aktivnim rezervacijama kartica koje su vezane za tekući račun klijenta.
Rezervacije se nalaze u tabeli OTHA_Rezervacije, a bitne kolone su: partija, pan, iznos i datum_aktiviranja.
Aktivne rezervacije su one rezervacije koje imaju u koloni OTHA_Rezervacije.status vrijednost 1.      

 Napomena: Da bi znali koja je kartica vezana za koji tekuči račun potrebno je prethodno dohvatiti sve kartice vezane za neki račun pa onda po njima dohvatiti rezervacije.

              
Navedeni podaci se mogu pronaći u tabelama CC_Cards (kolone: card_number, account, brand, type, kind, valid_thru, customer_id) i cc_Partije_Eksterne (kolona: exPartija).
Aktivne kartice su one kartice koje u koloni CC_Cards.card_status imaju status 1.

Potrebno je koristiti bazu podataka wbanka_nlb_test koja se nalazi na server 172.10.20.141.

 
 Napomena: Kao input prilikom poziva metode treba da unesemo matični broj, a kao rezultat da dobijemo sve prethodno navedeno u sljedećoj strukturi:

 

Račun:

-        Broj računa

-        Stanje

-        Transakcije:

            o   Datum

            o   Vrijeme

            o   Iznos

            o   Opis

            o   DetaljniOpis

            o   Provizija

            o   DP


-        Kartice

           o   BrojKartice

           o   PartijaKartice

           o   Brand

           o   Tip

           o   DatumVazenja


-        Rezervacije

          o   Kartica

          o   Iznos

          o   DatumAktiviranja