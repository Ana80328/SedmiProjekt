1.	Uvod
1.1	Svrha aplikacije

Kroz vježbu kolegija Razvoj poslovnih aplikacija stvoriti će se aplikacija za albume koja
podržava unos, uređivanje, brisanje, pretragu i opis albuma u bazi. Aplikacija treba
omogućiti brisanje i prikaz detalja albuma. Svaki unos podataka kroz aplikaciju treba
uključivati provjeru valjanosti i za brisanje podataka je potrebna potvrda korisnika.

1.2	Korisnici aplikacije

Svima koji posjeduju pristup internetu i web pregledniku, omogućit će se pristup sveobuhvatnim informacijama o albumima na jedinstvenoj platformi.

1.3	Koristi (benefiti) od aplikacije
Bit će stvorena centralizirana baza podataka o albumima koja će biti dostupna svim korisnicima. Umjesto da korisnici koriste Google i istražuju različite opcije za dobivanje informacija o albumima, sada će moći pristupiti svim potrebnim informacijama o albumima na jednom mjestu putem aplikacije. Aplikacija će biti dostupna preko interneta, što znači da će korisnici imati mogućnost korištenja aplikacije kad god to žele.

2.	Zahtjevi
2.1	Funkcijski zahtjevi

Aplikacija mora omogućiti spremanje, uređivanje, pretraživanje, prikaz, traženje i brisanje albuma u
bazi podataka.
2.2	Sistemski, hardverski i mrežni zahtjevi

Aplikacija će biti razvijena u ASP.NET Core MVC-u te ona treba biti smještena na Microsoft
Web poslužitelju (eng. server). 
Preporučene su sljedeće hardverske specifikacije:
Minimum četverojezgreni procesor 2.2 GHz
Minimum 30GB RAM memorije
Minimum 1TB prostora
Operativni sustav Windows server 2019.

2.2.1 Web server
Preporučuje se korištenje Windows Azure platforme za hosting aplikacije. Windows Azure omogućuje hosting bilo koje ASP.NET Core MVC aplikacije, uključujući i našu predloženu aplikaciju iz ovog dokumenta. Instalacija je jednostavna jer Microsoft brine o dodavanju resursa na poslužitelju tijekom razdoblja visokog prometa. Troškovi su minimalni i ovise o količini podataka prikazanih posjetiteljima, a održavanje hardvera nije uključeno u njih.

2.2.2 Baze podataka
Preporučuje se korištenje SQL SERVER baze podataka unutar Windows Azure-a za temeljnu
bazu podataka aplikacije. Što se tiče Web poslužitelja, ova preporuka osigurava visoku dostupnost
za bazu podataka s dobrim omjerom vrijednosti za uložen novac. To posebno ima smisla ako je I
Web aplikacija hostana na Windows Azure-u.

2.3	Sigurnost

U kasnijem razvoju aplikacije razvit će se sigurna identifikacija i zaštićena autentifikacija gdje
korisnička imena i lozinke ne smiju biti spremljene u obična tekstualna polja i datoteke, a ostali
podaci korisnika kao što su adresa, telefonski brojevi, brojevi kreditnih kartica i ostalih osobnih informacija neće biti dostupni anonimnim pristupom.

2.4	Korisnički zahtjevi

Tablica. Korisnički zahtjevi
Rb.	Zahtjev	Vrsta korisnika (user / admin)
1.	Prikaz svih albuma i žanrova	Anonimni korisnik
2.	Pretraga albuma po žanru i nazivu	Anonimni korisnik
3.	Unos albuma 	Registrirani korisnik
4.	Uređivanje albuma	Registrirani korisnik
5.	Brisanje albuma	Administrator
6.	Provjera valjanosti podataka kod unosa I uređivanja	Registrirani korisnik
7.	Potvrda s pitanjem “Jeste li sigurni?” kod brisanja albuma	Administrator
8.	Prikaz detalja o pojedinom albumu	Anonimni korisnik
9.	Početna stranica dolaska na aplikaciji mora sadržavati osnovne informacije o svrsi aplikacije	Anonimni korisnik


2.5	Slučajevi (scenariji) korištenja (use-case dijagrami) 
Sljedeći slučajevi korištenja opisuju scenarije u kojima korisnici web aplikacije koriste predloženu aplikaciju za upravljanje albumima. U tim slučajevima korištenja su uključene osnovne operacije, stoga ih ne treba smatrati konačnim. Kako napreduje razvoj dodatna funkcionalnost može biti dodana prema odluci SCRUM mastera.

2.5.1. Slučaj korištenja 1: Pregled albuma

Kada posjetitelj stranice pregledava Albume koji se nalaze u web aplikaciji, odvijaju se sljedeći koraci:
1.	Posjetitelj dolazi na početnu stranicu web mjesta kao anonimni korisnik ili klikne na link Početna stranica u izborniku ako se nalazio na drugoj stranici na istom web mjestu.
2.	Početna stranica prikazuje osnovni opis web aplikacije i sadrži gumbe za prikaz, pretraživanje i dodavanje novih albuma. 
3.	Prikaz osnovnih informacija o razvojnom timu nalaze se na stranicama O nama i Kontakt.
4.	Ako anonimni korisnik želi vidjeti sve albume u bazi, mora kliknuti na link Popis albuma u glavnom izborniku ili gumb prikaži na Početnoj stranici.
5.	Web aplikacija prikazuje popis albuma. Za svaki album se prikazuje naziv albuma, naziv izvođača, godina izlaska albuma, žanr, te cijena.
6.	Ako anonimni korisnik želi pretraživati albume u bazi po žanru i nazivu, mora kliknuti na link Tražilica albuma u glavnom izborniku.
7.	 Ako anonimni korisnik želi vidjeti detalje albuma, mora kliknuti na link Detalji za taj album.
8.	Web aplikacija prikazuje detalje odabranog albuma - naziv albuma, naziv izvođača, godina izlaska albuma, žanr, te cijena.








2.5.2.	Slučaj korištenja 2: Dodavanje novog albuma
Svi korisnici trebaju moći dodati novi Album. Kada korisnik dodaje novi Album, sljedeći koraci se odvijaju:
1.	Korisnik klikne na gumb Unos na Početnoj stranici ili na link Novi album na stranicama Popis albuma ili Tražilica albuma.
2.	Korisnik upisuje podatke o novom Albumu.
3.	Korisnik klikne na gumb Spremi.
4.	Ako su upisani podaci ispravni, web aplikacija sprema Album u bazu i vraća korisnika na stranicu Popis albuma

6.5.3.	 Slučaj korištenja 3: Uređivanje albuma

Kada korisnik uređuje Album, sljedeći koraci se odvijaju:
1.	Korisnik klikne na link Uredi u popisu albuma na stranicama Popis albuma ili  Tražilica albuma.
2.	Korisnik mijenja postojeće podatke o albumu.
3.	Korisnik klikne gumb Spremi promjene.
4.	Ako su upisani podaci točni, web aplikacija sprema promjene u bazi i prikazuje stranicu za Popis albuma.

2.5.4.	Slučaj korištenja 4: Brisanje albuma
Kad korisnik briše album iz baze podataka web aplikacije, sljedeći koraci se odvijaju:

1.	Korisnik klikne na link Obriši u popisu albuma na stranicama Popis albuma ili  Tražilica albuma.
2.	Web aplikacija zahtijeva potvrdu o brisanju albuma.
3.	Ako korisnik potvrđuje brisanje, album je uklonjen iz baze.
4.	Web aplikacija prikazuje stranicu Popis albuma.

2.6.	Dijagrami klasa 

Klasa Albumi je potrebna kako bi se u aplikaciji evidentirali osnovni podaci za album. Svojstva koja opisuju neki album su: ID (identifikator albuma), Izvođač (autor albuma, tekstni podatak), Album (naslov albuma, tekstualni podatak), Datum (datum izlaska albuma, tekstualni podatak), Cijena (cijena, decimalni broj), Žanr (žanr, tekstualni podatak) 
Kako bi se podaci o albumu mogli spremiti u bazu podataka, potrebno je napraviti klasu AppDBContext koja koristi klasu Albumi kao model za izradu tablice u bazi pomoću Entity frameworka pa zbog toga i nasljeđuje klasu DbContext. Nakon toga treba pristupiti razvoju kontrolera AlbumController koji mora naslijediti baznu klasu Kontroler s pripadajućim metodama za manipulaciju nad bazom.  


