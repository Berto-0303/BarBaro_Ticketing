Link github:https://github.com/Berto-0303/BarBaro_Ticketing

Probleme/Limitari: Probleme minore legate de instalarile unor framework-uri, diverse update-uri care nu se instalau asa cum trebuie pentru docker, in general chestii de configurat, nu propiu zis din proiect.






Definirea Arhitecturii a echipei Barbaro

Arhitectura se imparte in 3 mari categorii:
- Frontend
- Backend
- Database

Frontend-ul sistemului de ticketing va avea o interfata simpla, intuitiva si moderna. Pentru a ajunge le aceste rezultate s-au utilizat urmatoarele tehnologii:
-Swagger: el se foloseste pentru integrarea si testarea API-ului de backend aceasta va mai permite utilizatorilor si dezvoltatorilor sa exploreze API-ul direct dintr-o interfață web interactiva [+POSTMAN initial]
Interfata de frontend va permite utilizatorilor sa foloseasca urmatoarele functii:
-Crearea unui tichet
-Vizualizarea starii tichetelor
-Gestionarea tichetelor prin opțiuni precum editare sau ștergere
Backend-ul va reprezenta nucleul logic al aplicației, responsabil pentru gestionarea cererilor și operațiilor asupra bazei de date:
-Limbaj de programare: C#
-Framework: Backend-ul va fi dezvoltat utilizând ASP.NET Core
Backend-ul va expune API-uri RESTful pentru comunicarea cu frontend-ul. Controllers vor gestiona cererile HTTP GET, POST, PUT, DELETE pentru operațiile CRUD asupra tichetelor
Baza de Date e responsabilă pentru stocarea și gestionarea datelor aplicației:
SQLite: un sistem de gestionare a bazelor de date ușor, rapid și portabil care este ideal pentru proiectele care nu necesită o infrastructură complexă.