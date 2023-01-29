using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

class Debtor
{
    public Debtor(string fullname, DateTime birthDay, string phone, string email, string address, int debt)
    {
        this.FullName = fullname;
        this.BirthDay = birthDay;
        this.Phone = phone;
        this.Email = email;
        this.Address = address;
        this.Debt = debt;
    }

    public string FullName { get; set; }
    public DateTime BirthDay { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public int Debt { get; set; }
    public override string ToString()
    {
        return $"{this.FullName} {this.BirthDay.ToShortDateString()} {this.Phone} {this.Email} {this.Address} {this.Debt}";
    }
}

class Program
{
    static public List<Debtor> debtors = new List<Debtor> {
        new Debtor("Shirley T. Qualls", DateTime.Parse("March 30, 1932"), "5306627732", "ShirleyTQualls@teleworm.us", "3565 Eagles Nest Drive Woodland, CA 95695", 2414),
        new Debtor("Danielle W. Grier", DateTime.Parse("October 18, 1953"), "3214734178", "DanielleWGrier@rhyta.com", "1973 Stoneybrook Road Maitland, FL 32751", 3599),
        new Debtor("Connie W. Lemire", DateTime.Parse("June 18, 1963"), "8283213751", "ConnieWLemire@rhyta.com", "2432 Hannah Street Andrews, NC 28901", 1219),
        new Debtor("Coy K. Adams", DateTime.Parse("March 1, 1976"), "4103471307", "CoyKAdams@dayrep.com", "2411 Blue Spruce Lane Baltimore, MD 21202", 3784),
        new Debtor("Bernice J. Miles", DateTime.Parse("June 1, 1988"), "9123076797", "BerniceJMiles@armyspy.com", "4971 Austin Avenue Savannah, GA 31401", 4060),
        new Debtor("Bob L. Zambrano", DateTime.Parse("February 28, 1990"), "7064461649", "BobLZambrano@armyspy.com", "2031 Limer Street Augusta, GA 30901", 6628),
        new Debtor("Adam D. Bartlett", DateTime.Parse("May 6, 1950"), "6506931758", "AdamDBartlett@rhyta.com", "2737 Rardin Drive San Jose, CA 95110", 5412),
        new Debtor("Pablo M. Skinner", DateTime.Parse("August 26, 1936"), "6303912034", "PabloMSkinner@armyspy.com", "16 Fraggle Drive Hickory Hills, IL 60457", 11097),
        new Debtor("Dorothy J. Brown", DateTime.Parse("July 9, 1971"), "2704563288", "DorothyJBrown@rhyta.com", "699 Harper Street Louisville, KY 40202", 7956),
        new Debtor("Larry A. Miracle", DateTime.Parse("May 22, 1998"), "3016213318", "LarryAMiracle@jourrapide.com", "2940 Adams Avenue Columbia, MD 21044", 7150),
        new Debtor("Donna B. Maynard", DateTime.Parse("January 26, 1944"), "5202970575", "DonnaBMaynard@teleworm.us", "4821 Elk Rd Little Tucson, AZ 85704", 2910),
        new Debtor("Jessica J. Stoops", DateTime.Parse("April 22, 1989"), "3603668101", "JessicaJStoops@dayrep.com", "2527 Terra Street Custer, WA 98240", 11805),
        new Debtor("Audry M. Styles", DateTime.Parse("February 7, 1937"), "9787734802", "AudryMStyles@jourrapide.com", "151 Christie Way Marlboro, MA 01752", 1001),
        new Debtor("Violet R. Anguiano", DateTime.Parse("November 4, 1958"), "5853407888", "VioletRAnguiano@dayrep.com", "1460 Walt Nuzum Farm Road Rochester, NY 14620", 9128),
        new Debtor("Charles P. Segundo", DateTime.Parse("October 21, 1970"), "4153673341", "CharlesPSegundo@dayrep.com", "1824 Roosevelt Street Fremont, CA 94539", 5648),
        new Debtor("Paul H. Sturtz", DateTime.Parse("September 15, 1944"), "3363761732", "PaulHSturtz@dayrep.com", "759 Havanna Street Saxapahaw, NC 27340", 10437),
        new Debtor("Doris B. King", DateTime.Parse("October 10, 1978"), "2052318973", "DorisBKing@rhyta.com", "3172 Bedford Street Birmingham, AL 35203", 7230),
        new Debtor("Deanna J. Donofrio", DateTime.Parse("April 16, 1983"), "9528427576", "DeannaJDonofrio@rhyta.com", "1972 Orchard Street Bloomington, MN 55437", 515),
        new Debtor("Martin S. Malinowski", DateTime.Parse("January 17, 1992"), "7655993523", "MartinSMalinowski@dayrep.com", "3749 Capitol Avenue New Castle, IN 47362", 1816),
        new Debtor("Melissa R. Arner", DateTime.Parse("May 24, 1974"), "5305087328", "MelissaRArner@armyspy.com", "922 Hill Croft Farm Road Sacramento, CA 95814", 5037),
        new Debtor("Kelly G. Hoffman", DateTime.Parse("September 22, 1969"), "5058768935", "KellyGHoffman@armyspy.com", "4738 Chapmans Lane Grants, NM 87020", 7755),
        new Debtor("Doyle B. Short", DateTime.Parse("June 15, 1986"), "9892214363", "DoyleBShort@teleworm.us", "124 Wood Street Saginaw, MI 48607", 11657),
        new Debtor("Lorrie R. Gilmore", DateTime.Parse("December 23, 1960"), "7243067138", "LorrieRGilmore@teleworm.us", "74 Pine Street Pittsburgh, PA 15222", 9693),
        new Debtor("Lionel A. Cook", DateTime.Parse("April 16, 1972"), "2016275962", "LionelACook@jourrapide.com", "29 Goldleaf Lane Red Bank, NJ 07701", 2712),
        new Debtor("Charlene C. Burke", DateTime.Parse("January 18, 1990"), "483349729", "CharleneCBurke@armyspy.com", "4686 Renwick Drive Philadelphia, PA 19108", 4016),
        new Debtor("Tommy M. Patton", DateTime.Parse("June 30, 1981"), "7745716481", "TommyMPatton@rhyta.com", "748 Rockford Road Westborough, MA 01581", 349),
        new Debtor("Kristin S. Bloomer", DateTime.Parse("June 16, 1944"), "4436520734", "KristinSBloomer@dayrep.com", "15 Hewes Avenue Towson, MD 21204", 9824),
        new Debtor("Daniel K. James", DateTime.Parse("November 10, 1997"), "8014074693", "DanielKJames@rhyta.com", "3052 Walton Street Salt Lake City, UT 84104", 8215),
        new Debtor("Paula D. Henry", DateTime.Parse("September 6, 1976"), "6183785307", "PaulaDHenry@rhyta.com", "3575 Eagle Street Norris City, IL 62869", 5766),
        new Debtor("Donna C. Sandoval", DateTime.Parse("December 13, 1947"), "5404825463", "DonnaCSandoval@rhyta.com", "675 Jehovah Drive Martinsville, VA 24112", 8363),
        new Debtor("Robert T. Taylor", DateTime.Parse("August 17, 1932"), "2705966442", "RobertTTaylor@armyspy.com", "2812 Rowes Lane Paducah, KY 42001", 7785),
        new Debtor("Donna W. Alamo", DateTime.Parse("December 9, 1948"), "9787782533", "DonnaWAlamo@teleworm.us", "4367 Christie Way Marlboro, MA 01752", 10030),
        new Debtor("Amy R. Parmer", DateTime.Parse("May 19, 1995"), "4808834934", "AmyRParmer@armyspy.com", "85 Elmwood Avenue Chandler, AZ 85249", 5347),
        new Debtor("Newton K. Evans", DateTime.Parse("October 8, 1986"), "3032079084", "NewtonKEvans@rhyta.com", "3552 Columbia Road Greenwood Village, CO 80111", 9838),
        new Debtor("Kathleen C. Chaney", DateTime.Parse("January 5, 1949"), "6052453513", "KathleenCChaney@rhyta.com", "316 Elsie Drive Fort Thompson, SD 57339", 1672),
        new Debtor("Manuel C. Johnson", DateTime.Parse("February 23, 1957"), "6062472659", "ManuelCJohnson@jourrapide.com", "4146 May Street Sharpsburg, KY 40374", 9195),
        new Debtor("Carla A. Creagh", DateTime.Parse("November 21, 1988"), "6143078974", "CarlaACreagh@dayrep.com", "3106 Bates Brothers Road Columbus, OH 43215", 11271),
        new Debtor("Norma M. New", DateTime.Parse("May 18, 1988"), "8574928703", "NormaMNew@jourrapide.com", "965 Metz Lane Woburn, MA 01801", 9761),
        new Debtor("Roy D. Green", DateTime.Parse("January 27, 1983"), "3083405981", "RoyDGreen@jourrapide.com", "401 Romrog Way Grand Island, NE 68801", 10771),
        new Debtor("Cristy J. Jensen", DateTime.Parse("November 2, 1935"), "4406269550", "CristyJJensen@jourrapide.com", "2177 Harley Vincent Drive Cleveland, OH 44113", 5205),
        new Debtor("Nancy J. Fergerson", DateTime.Parse("June 10, 1993"), "2199878498", "NancyJFergerson@dayrep.com", "3584 Jadewood Drive Demotte, IN 46310", 1276),
        new Debtor("Dave N. Rodriguez", DateTime.Parse("January 21, 1938"), "2145402499", "DaveNRodriguez@rhyta.com", "1890 Poco Mas Drive Dallas, TX 75247", 9132),
        new Debtor("James E. Denning", DateTime.Parse("May 4, 1988"), "5042898640", "JamesEDenning@jourrapide.com", "1444 Rose Avenue Metairie, LA 70001", 8176),
        new Debtor("Richard M. Thomas", DateTime.Parse("February 13, 1972"), "5107353359", "RichardMThomas@jourrapide.com", "4454 Green Avenue Oakland, CA 94609", 7875),
        new Debtor("Lakisha R. Forrest", DateTime.Parse("December 1, 1973"), "3348301181", "LakishaRForrest@armyspy.com", "3121 Quarry Drive Montgomery, AL 36117", 3088),
        new Debtor("Pamela H. Beauchamp", DateTime.Parse("November 20, 1959"), "1234567890", "PamelaHBeauchamp@jourrapide.com", "3239 Tori Lane Salt Lake City, UT 84104", 6588)
    };



    static void Main()
    {
        //1) rhyta.com ve ya dayrep.com domenlerinde emaili olan borclulari cixartmag ++

        var result = debtors.Where(db => db.Email.EndsWith("rhyta.com") || db.Email.EndsWith("dayrep.com")).ToList();
        //result.ForEach(db => Console.WriteLine(db.FullName + db.Email));


        //2) Yashi 26 - dan 36 - ya qeder olan borclulari cixartmag ++

        var result2 = debtors.Where(db => 26 < DateTime.Now.Year - db.BirthDay.DayOfYear && DateTime.Now.Year - db.BirthDay.Year < 36).ToList();
        //result2.ForEach(db => Console.WriteLine(db.FullName + db.BirthDay));


        //3) Borcu 5000 - den cox olmayan borclularic cixartmag ++

        var result3 = debtors.Where(db => db.Debt < 5000).ToList();
        //result3.ForEach(db => Console.WriteLine(db.FullName + ": " + db.Debt));


        //4) Butov adi 18 simvoldan cox olan ve telefon nomresinde 2 ve ya 2 - den cox 7 reqemi olan borclulari cixartmaq ++

        var result4 = debtors.Where(db => db.FullName.Length > 18 && db.Phone.Count(c => c == '7') >= 2).ToList();
        //result4.ForEach(db => Console.WriteLine(db.FullName + ": " + db.Phone));


        //5) Qishda anadan olan borclulari cixardmaq ++

        var result5 = debtors.Where(db => db.BirthDay.Month == 1 || db.BirthDay.Month == 2 || db.BirthDay.Month == 12).ToList();
        //result5.ForEach(db => Console.WriteLine(db.FullName + ": " + db.BirthDay));


        //6) Borcu, umumi borclarin orta borcunnan cox olan borclulari cixarmaq ve evvel familyaya gore sonra ise meblegin azalmagina gore sortirovka etmek ++ 

        var totalDebt = debtors.Select(db => db.Debt).Sum();
        var averageDebt = totalDebt / debtors.Count();
        //Console.WriteLine($"Average Debt: {averageDebt}");


        var result6 = debtors.Where(db => db.Debt > averageDebt).ToList();

        result6.Sort(delegate (Debtor a, Debtor b) { return b.FullName.CompareTo(a.FullName); });

        result6.Sort(delegate (Debtor a, Debtor b) { return b.Debt.CompareTo(a.Debt); });


        //result6.ForEach(db => Console.WriteLine(db.FullName + ": " + db.Debt));



        //7) Telefon nomresinde 8 olmayan borclularin yalniz familyasin, yashin ve umumi borcun meblegin cixarmaq ++

        Predicate<Debtor> pre = delegate (Debtor d) { return d.Phone.Contains('8') ? false : true; };

        var result7 = debtors.Where(db => pre(db)).Select(db => db.FullName + " " + (DateTime.Now.Year - db.BirthDay.Year) + " " + db.Debt).ToList();

        //result7.ForEach(db => Console.WriteLine(db));


        //8)Adinda ve familyasinda hec olmasa 3 eyni herf olan borclularin siyahisin cixarmaq ve onlari elifba sirasina gore sortirovka elemek ++

        var result8 = debtors.Select(db => db.FullName).ToList(); 
        var result8after = new List<string>();

        foreach (string item in result8)
        {
            for (int i = 0; i < item.Length - 2; i++)
            {
                if (item[i] == item[i + 1] && item[i + 1] == item[i + 2])
                {
                    result8after.Add(item);
                    break;
                }
            }
        }

        //result8after.ForEach(db => Console.WriteLine(db));






        //9)borclulardan en coxu hansi ilde dogulubsa hemin ili cixartmaq ++

        var result9 = debtors.Select(db => db.BirthDay.Year).ToList();

        var frequency = result9.GroupBy(i => i).OrderByDescending(g => g.Count()).First().Key;

        //Console.WriteLine(frequency);


        //10)Borcu en boyuk olan 5 borclunun siyahisini cixartmaq ++

        var result10 = debtors.Select(db => db).ToList();

        result10.Sort(delegate (Debtor a, Debtor b) { return b.Debt.CompareTo(a.Debt); });

        //for (int i = 0; i < 5; i++)
        //{
        //    Console.WriteLine(result10[i]);
        //}





        //11)Butun borcu olanlarin borcunu cemleyib umumi borcu cixartmaq ++

        var result11 = debtors.Select(db => db.Debt).Sum();
        //Console.WriteLine($"Total Debt: {result11}");



        //12)2ci dunya muharibesin gormush borclularin siyahisi cixartmaq ++

        var result12 = debtors.Where(db => db.BirthDay.Year <= 1941).ToList();
        //result12.ForEach(db => Console.WriteLine(db.FullName + ": " + db.BirthDay));


        //13)Nomresinde tekrar reqemler olmayan borclularin ve onlarin borcunun meblegin cixartmaq ++

        var result13 = debtors.Select(db => long.Parse(db.Phone)).ToList();
        List <long> result13after = new List<long>();

        

        foreach (long item in result13)
        {
            bool hasDuplicates = false;
            int[] digits = item.ToString().Select(x => int.Parse(x.ToString())).ToArray();

            for (int i = 0; i < digits.Length; i++)
            {
                for (int j = i + 1; j < digits.Length; j++)
                {
                    if (digits[i] == digits[j])
                    {
                        hasDuplicates = true;
                        break;
                    }
                }
            }

            if (!hasDuplicates)
            {
                result13after.Add(item);
            }
        }

        //result13after.ForEach(db => Console.WriteLine(db));




        //14)Tesevvur edek ki,butun borclari olanlar bugunden etibaren her ay 500 azn pul odeyecekler.Oz ad gunune kimi borcun oduyub qurtara bilenlerin siyahisin cixartmaq ++


        var result14 = debtors.Where(db => (500 * (db.BirthDay.Month - DateTime.Now.Month)) == db.Debt).ToList();
        //result14.ForEach(db => Console.WriteLine(db.FullName + ": " + db.BirthDay));




        //15)Adindaki ve familyasindaki herflerden "smile" sozunu yaza bileceyimiz borclularin siyahisini cixartmaq ++

        var result15 = debtors.Where(db => db.FullName.Contains('s') && db.FullName.Contains('m') && db.FullName.Contains('i') && db.FullName.Contains('l') && db.FullName.Contains('e')).ToList();
        //result15.ForEach(db => Console.WriteLine(db.FullName));


    }
}