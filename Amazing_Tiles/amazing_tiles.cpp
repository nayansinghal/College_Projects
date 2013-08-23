#include <iostream>
using namespace std;
#include <stdlib.h>
#include <conio.h>
#include<windows.h>
#include<fstream>
#include<map>
#include<iomanip>
char a[4][4];
char S=(char)176,D=(char)178;
int move=0;

//Display "Win" page 
void won()
{ 
    HANDLE hConsole( GetStdHandle(STD_OUTPUT_HANDLE) );
    COORD pos;
    char cText[300];
    strcpy(cText, "                                                                                ");
    strcat(cText, "YOU WIN THE GAME  ");
    strcat(cText, "                                                                                ");
    int d, i, j, tl = strlen(cText)-80;
    for (i=0;i<tl;i++)
    {
    for (j=0;j<80;j++)
    {
    pos.X = j;
    pos.Y = 5;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), pos);
    printf("%c", cText[i+j]);
     
    }
    Sleep(100);
}
}   

//Display "Starting" page - skull, A.R.T. Production 
void skll()
{
system("color 0f");
cout<<"    \n";
cout<<"   \n";
cout<<"    \n";
cout<<"                   !!~  ~:~!! :~!$!#$$$$$$$$$$8X:!                    \n";
cout<<"                   !~::!H!~   ~.U$X!?R$$$$$$$$MM~/                    \n";
cout<<"                  ~!~!!!!~~ .:XW$$$U!!?$$$$$$RMM!                     \n";
cout<<"                    !:~~~ .:!M'T#$$$$WX??#MRRMMM!                     \n";
cout<<"                    ~?WuxiW*`   `'#$$$$8!!!!??!!!                     \n";
cout<<"                  :X- M$$$$       `'T#$T~!8$WUXU~                     \n";
cout<<"                 :#`  ~#$$$m:    0   ~!~ ?$$$$$$                      \n";
cout<<"               :!`.-   ~T$$$$8xx.  .xWW- ~''##*'                      \n";
cout<<"     .....   -~~:!` !    ~?T#$$@@W@*?$$  0   /`                       \n";
cout<<"     W$@@M!!! .!~~ !!     .:XUW$W!~ `'~:    :                         \n";
cout<<"     #'~~`.:x)`!!  !H:   !WM$$$$Ti.: .!WUn+!`        A . R . T .      \n";
cout<<"     :::~:!!`:X~ .: ?H.!u '$$$B$$$!W:U!T$$M~                          \n";
cout<<"     .~~   :X@!.-~   ?@WTWo('*$$$W$TH$! `            PRODUCTION       \n";
cout<<"     Wi.~!X$?!-~    : ?$$$B$Wu('**$RM!                                \n";
cout<<"     $R@i.~~ !     :   ~$$$$$B$$en:``                                 \n";
cout<<"     ?MXT@Wx.~    :    / ~'##*$$$$M~                   \n";
cout<<"                            $$$$$'                                    \n";
cout<<"                                                                      \n";
Sleep(5000);
system("cls");
}

//Display " Amazing Title Bar " 
void tle()
{
  char M=(char)178;
  cout<<"\t\t\t"<<M<<M<<M<<M<<"  "<<M<<" "<<M<<"  "<<M<<M<<M<<M<<" "<<M<<M<<M<<M<<M<<" "<<M<<" "<<M<<M<<"    "<<M<<" "<<M<<M<<M<<M<<"\n";
 cout<<"\t\t\t"<<M<<"  "<<M<<" "<<M<<" "<<M<<" "<<M<<" "<<M<<"  "<<M<<"     "<<M<<" "<<M<<" "<<M<<" "<<M<<"   "<<M<<" "<<M<<"\n";
 cout<<"\t\t\t"<<M<<M<<M<<M<<" "<<M<<" "<<M<<" "<<M<<" "<<M<<M<<M<<M<<" "<<M<<M<<M<<M<<M<<" "<<M<<" "<<M<<"  "<<M<<"  "<<M<<" "<<M<<" "<<M<<M<<"\n";
 cout<<"\t\t\t"<<M<<"  "<<M<<" "<<M<<"   "<<M<<" "<<M<<"  "<<M<<" "<<M<<"     "<<M<<" "<<M<<"   "<<M<<" "<<M<<" "<<M<<"  "<<M<<"\n"; 
 cout<<"\t\t\t"<<M<<"  "<<M<<" "<<M<<"   "<<M<<" "<<M<<"  "<<M<<" "<<M<<M<<M<<M<<M<<" "<<M<<" "<<M<<"    "<<M<<M<<" "<<M<<M<<M<<M<<"\n"; 
 cout<<"\n\n\n";
 cout<<"\t\t\t\t"<<M<<M<<M<<M<<M<<" "<<M<<" "<<M<<"    "<<M<<M<<M<<M<<" "<<M<<M<<M<<M<<"\n";
 cout<<"\t\t\t\t"<<"  "<<M<<"   "<<M<<" "<<M<<"    "<<M<<"    "<<M<<"\n";
 cout<<"\t\t\t\t"<<"  "<<M<<"   "<<M<<" "<<M<<"    "<<M<<M<<M<<M<<" "<<M<<M<<M<<M<<"\n";
 cout<<"\t\t\t\t"<<"  "<<M<<"   "<<M<<" "<<M<<"    "<<M<<"       "<<M<<"\n"; 
 cout<<"\t\t\t\t"<<"  "<<M<<"   "<<M<<" "<<M<<M<<M<<M<<" "<<M<<M<<M<<M<<" "<<M<<M<<M<<M<<"\n";
}

//Makes the Amazing Title Bar moves Up and Down
void title()
{
 system("color 21");
 system("cls");
 HANDLE hConsole( GetStdHandle(STD_OUTPUT_HANDLE) );
 COORD pos;
    int i=0,j=0;
    for( i=0;i<6;i+=2)
    {
    for( j=0;j<9-i;j++)
      {
       system("cls");
       pos.X = 0;
       pos.Y = j+i;
   SetConsoleCursorPosition( hConsole, pos );
   tle();
   Sleep(150);
   }
   Sleep(200);
 for( j=0;j<6-i;j+=2)
  {
   system("cls");
   pos.Y=10-j;
   SetConsoleCursorPosition( hConsole, pos );
   tle();
   Sleep(150);
}
cout<<"  ";
}
cout<<"\t\t\t\t  all rights reserved             ";

 for(int i=0;i<15;i++)
   {
   pos.X = 38;
   pos.Y = 0+i;
   if(i<=8)
   cout<<"\b\b"<<'\0'<<'\0';
   if(i==8)
   {
    pos.Y=16;
    i=14;
   }
 SetConsoleCursorPosition( hConsole, pos );
 cout<<"@";
 Sleep(200);
  }
  cout<<"\b";
  Sleep(2000);
  system("cls");
}

//thanks page for buying the game
void thanks()
{
 cout<<"\n\n\n\t\t\t\t";
 cout<<"AMAZING    TILES\n";
 cout<<"\t\t\t\t-------    -----\n";
 cout<<"\n\t\t\t\t      V 1.0\n\n";
 cout<<"\t\t\t\t  MARCH 22,2011\n\n\n\n\n";
 cout<<"\t\t  Thank for you purchasing this Amazing tile Game\n\n";
 cout<<"\t\t It has always been my dream to be a game developer.\n\n";
 cout<<"\n\n\t\t\t\t\t\t\tNAYAN SINGHAL";
 Sleep(7000);
 system("cls");
}

//Instruction page
void instruct()
{
  cout<<"\n\n\n\t\t\t\t";
 cout<<"AMAZING    TILES\n";
 cout<<"\t\t\t\t-------    -----\n";
 cout<<"\n\n\n\t\t\t Highlight  all  paired  tiles  by  clicking\n\n";
 cout<<"\t\t\t\t them  with  a  ENTER  key!"; 
 Sleep(3000);
 system("cls");
}

//Display the Board of the Game
void cou()
{
 cout<<"\n\n";
 cout<<"\t\t      ______ ______ ______ ______ \n";
 cout<<"\t\t     |"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|\n";
 cout<<"\t\t     |"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|\n";
 cout<<"\t\t     |"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|\n";
 cout<<"\t\t     |"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|\n";
 cout<<"\t\t     |______|______|______|______|\n";
 cout<<"\t\t     |"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|\n";
 cout<<"\t\t     |"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|\n";
 cout<<"\t\t     |"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|\n";
 cout<<"\t\t     |"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|\n";
 cout<<"\t\t     |______|______|______|______|\n";
 cout<<"\t\t     |"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|\n";
 cout<<"\t\t     |"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|                   MOVE\n";
 cout<<"\t\t     |"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|                   ----\n";
 cout<<"\t\t     |"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|                    0 \n"; 
 cout<<"\t\t     |______|______|______|______|\n";
 cout<<"\t\t     |"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|\n";
 cout<<"\t\t     |"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|\n";
 cout<<"\t\t     |"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|\n";
 cout<<"\t\t     |"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|"<<D<<D<<D<<D<<D<<D<<"|"<<S<<S<<S<<S<<S<<S<<"|\n";
 cout<<"\t\t     |______|______|______|______|\n";
}
void trap(int x,int y)
{       HANDLE hConsole( GetStdHandle(STD_OUTPUT_HANDLE) );
        COORD pos;
        pos.X=x-2;
        pos.Y=y-1;
        SetConsoleCursorPosition( hConsole, pos );
        cout<<'\0'<<'\0'<<'\0'<<'\0'<<'\0'<<'\0';
        pos.X=x-2;
        pos.Y=y;
        SetConsoleCursorPosition( hConsole, pos );
        cout<<'\0'<<a[y%4][x%6]<<a[y%4][x%6]<<a[y%4][x%6]<<'\0'<<'\0';
        pos.X=x-2;
        pos.Y=y+1;
        SetConsoleCursorPosition( hConsole, pos );
        cout<<'\0'<<'\0'<<'\0'<<'\0'<<'\0'<<'\0';
        pos.X=x-2;
        pos.Y=y+2;
        SetConsoleCursorPosition( hConsole, pos );
        cout<<'\0'<<'\0'<<'\0'<<'\0'<<'\0'<<'\0';
        pos.X=x;
        pos.Y=y;
        SetConsoleCursorPosition( hConsole, pos );   
}

//Display the loading of the game
void loading()
{
        system("cls");
        system("color 0f");
        HANDLE hConsole( GetStdHandle(STD_OUTPUT_HANDLE) );
        COORD pos;
        pos.X=26;
        pos.Y=9;
        SetConsoleCursorPosition( hConsole, pos );
        cout<<"Loading ";
        pos.X+=7;
        for(int j=0;j<5;j++)
        {
        for(int i=0;i<5;i++)
        {
         pos.X+=1;
         SetConsoleCursorPosition( hConsole, pos );
         cout<<".";
         Sleep(300);
         }
         pos.X=33;
         SetConsoleCursorPosition( hConsole, pos );
         cout<<'\0'<<'\0'<<'\0'<<'\0'<<'\0'<<'\0';
          pos.X=33;
         SetConsoleCursorPosition( hConsole, pos );
         }
         system("cls");
}

//display the quit page and decide on the basis of user input
int quit()
{
     system("cls");
     system("color 1b");
     char d,b[49];
     d=(char)177;
     cout<<"\n\n\n\n\n\n\t\t";
     for(int i=0;i<50;i++)
     {
     cout<<d;
     if(i<48)
     b[i]=' ';
     }
     b[48]='\0';
     cout<<"\n";
     cout<<"\t\t"<<d<<b<<d<<"\n";
     cout<<"\t\t"<<d<<b<<d<<"\n";
     cout<<"\t\t"<<d<<" END GAME                                       "<<d<<"\n";
     cout<<"\t\t"<<d<<b<<d<<"\n";
     cout<<"\t\t"<<d<<b<<d<<"\n";
     cout<<"\t\t"<<d<<"        Are you sure you want to quit ?         "<<d<<"\n";
     cout<<"\t\t"<<d<<b<<d<<"\n";
     cout<<"\t\t"<<d<<"            YES              NO                 "<<d<<"\n";
     cout<<"\t\t"<<d<<b<<d<<"\n";
     cout<<"\t\t"<<d<<b<<d<<"\n";
     cout<<"\t\t"<<d<<b<<d<<"\n";
     cout<<"\t\t"<<d<<b<<d<<"\n\t\t";
     for(int i=0;i<50;i++)
     cout<<d;
     HANDLE hConsole( GetStdHandle(STD_OUTPUT_HANDLE) );
        COORD pos;
        pos.X=26;
        pos.Y=14;
        SetConsoleCursorPosition( hConsole, pos );
        cout<<(char)26;
        int nay;
        do
        {
         nay=getch();
         cout<<"\b"<<'\0';
         if(nay==100||nay==97)
         {
          if(pos.X==26)
          pos.X=43;
          else
          pos.X=26;
          SetConsoleCursorPosition( hConsole, pos );
          cout<<(char)26;
         }
         if(nay==13)
         {
          if(pos.X==26)
          return 0;
          else
          return 1;
         }
         }while(nay!=13);
}
void drag(char T,int x,int y)
{
        HANDLE hConsole( GetStdHandle(STD_OUTPUT_HANDLE) );
        COORD pos;
        pos.X=x-2;
        pos.Y=y-1;
        SetConsoleCursorPosition( hConsole, pos );
        cout<<T<<T<<T<<T<<T<<T;
        pos.X=x-2;
        pos.Y=y;
        SetConsoleCursorPosition( hConsole, pos );
        cout<<T<<T<<T<<T<<T<<T;
        pos.X=x-2;
        pos.Y=y+1;
        SetConsoleCursorPosition( hConsole, pos );
        cout<<T<<T<<T<<T<<T<<T;
        pos.X=x-2;
        pos.Y=y+2;
        SetConsoleCursorPosition( hConsole, pos );
        cout<<T<<T<<T<<T<<T<<T;
        pos.X=x;
        pos.Y=y;
        SetConsoleCursorPosition( hConsole, pos );   
} 
void add()
{
 a[0][0]=(int)1;a[0][1]=(int)14;a[0][2]=(int)3;a[0][3]=(int)1;
 a[1][0]=(int)3;a[1][1]=(int)234;a[1][2]=(int)5;a[1][3]=(int)227;
 a[2][0]=(int)15;a[2][1]=(int)228;a[2][2]=(int)14;a[2][3]=(int)227;
 a[3][0]=(int)5;a[3][1]=(int)234;a[3][2]=(int)15;a[3][3]=(int)228;
 
}

//display the highscore board of the game
void highscore()
{    system("cls");
     system("color 1b");
     string d[50];
     int td[50],m=0,n=0;
     map<int,string>na;
     ifstream inf("name.txt");
     ifstream fin("move.txt");
    if (!inf)
    {
      cerr << "Uh oh, Sample.dat could not be opened for reading!" << endl;
      exit(1);
    }
    while (inf&&fin)
    {
       string strInput;
       int a;
       inf >> strInput;
       fin>>a;
       na.insert(make_pair(a,strInput));
    }
    inf.close();
    fin.close();
    multimap<int,string>::iterator pos;
    for(pos=na.begin();pos!=na.end();pos++)
    {
     d[m++]=pos->second;
     td[n++]=pos->first;
    }
    cout<<"\n\n\n\t\t\t";
    cout<<"       HIGHSCORES\n";
    cout<<"\t\t\t       ----------\n\n";
    cout<<"                    SNO.  NAME                MOVES\n";
    cout<<"                    ---   ----                ----\n\n";
    for(int i=0;i<m;i++)
    {
    cout.setf (ios::left, ios::adjustfield);
    cout.width(10);
    cout<<setw(20)<<" "<<i+1<<setw(5)<<" "<<setw(20)<<d[i]<<td[i]<<"\n";
    }
}

//display the controls 
void control()
{
system("cls");
system("color 1b");
 cout<<"\n\n\t\t\t";
  cout<<"       CONTROLS\n";
  cout<<"\t\t\t       ========\n";
  cout<<"\n\n\t\t  POSITION                  BUTTONS\n";
  cout<<"\t\t  --------                  -------";
  cout<<"\n\n\t\t  LEFT                      A";
  cout<<"\n\n\t\t  RIGHT                     D";
  cout<<"\n\n\t\t  UP                        W";
  cout<<"\n\n\t\t  DOWN                      S";
  cout<<"\n\n\t\t  OK                        ENTER";
  cout<<"\n\n\t\t  QUIT                      ESC";      
}

//Display the "Input Name" page and user enter the name here
void nameinput()
{
 ofstream outf("name.txt",ios::app);
  if (!outf)
  {
    cerr << "Uh oh, Sample.dat could not be opened for writing!" << endl;
    exit(1);
  }
  cout<<"\n\n\n\t\t\t\t";
  cout<<"AMAZING    TILES\n";
  cout<<"\t\t\t\t-------    -----\n";
  cout<<"\n\n\n\t\t        ENTER YOUR NAME        ";  
  string name;
  cin>>name;
  outf << name << endl;
  outf.close();
}

//Write Number of moves to the output file
void moveinput()
{
  ofstream outf("move.txt",ios::app);
  if (!outf)
   {
    cerr << "Uh oh, Sample.dat could not be opened for writing!" << endl;
    exit(1);
   }
   outf << move << endl;
   outf.close();
}

//main function 
int main()
{
   skll();     
   title();
    thanks();
instruct();
   
    int c,b,win=0,d,e,f,g;
    for(int i=0;i<4;i++)
    for(int j=0;j<4;j++)
     a[i][j]='\0';
     p:
        system("cls");
        system("color bc");
        char u=(char)221;
        char t=(char)219;
        char v=(char)222;
        cout<<"\n\n\n";
        cout<<"\t\t\t";   
		//show the Menu page having options - start,highscores, controls, exit
      for(int i=0;i<30;i++)
      cout<<t;
      cout<<"\n";
      cout<<"\t\t\t"<<u<<"                            "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"                            "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"                            "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"         START              "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"                            "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"                            "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"         HIGHSCORE          "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"                            "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"                            "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"         CONTROLS           "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"                            "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"                            "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"         EXIT               "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"                            "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"                            "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"                            "<<v<<"\n";
      cout<<"\t\t\t"<<u<<"                            "<<v<<"\n";
      cout<<"\t\t\t";
      for(int i=0;i<30;i++)
      cout<<t;
          HANDLE hConsole( GetStdHandle(STD_OUTPUT_HANDLE) );
          COORD pos;
          pos.X=28;
          pos.Y=7;
          SetConsoleCursorPosition( hConsole, pos );
          cout<<(char)26;
         int ky;
         do
         {
          ky=getch();
          cout<<"\b"<<'\0';
          if(ky==115)
          {
           if(pos.Y==16)
           pos.Y=7;
           else
           pos.Y+=3;
           SetConsoleCursorPosition( hConsole, pos );
          cout<<(char)26;
          }
          if(ky==119)
          { if(pos.Y==7)
           pos.Y=16;
           else
           pos.Y-=3;
           SetConsoleCursorPosition( hConsole, pos );
          cout<<(char)26;
          }
          if(ky==13)
         {
          if(pos.Y==7)
          break;
          if(pos.Y==10)
          {
          system("cls");
          highscore();
          cout<<"\n\n\n\t\t\t\t BACK  "<<(char)27;
          int sd;
          z:
          sd=getch();
          if(sd==13)
          goto p;
          else
          goto z; 
          }
          if(pos.Y==13)
           {
           control();
           cout<<"\n\n\n\t\t\t\t BACK  "<<(char)27;
           int sn;
          w:
          sn=getch();
          if(sn==13)
          goto p;
          else
          goto w; 
          }
          else
          {
           system("cls");
           int x=quit();
           if(x==1)
           goto p;
           else
           exit(0);
          }
          }
        }while(ky!=13);
         system("cls");
         loading();
        
    q:
         system("cls"); 
         system("color 0b");   
         add();
         cou();
    
         move =0;
         pos.X = 24;
         pos.Y = 4;
 SetConsoleCursorPosition( hConsole, pos );
 int key;
 int sum=0;
 do
 {
 
 key=getch();
 if(key==100)
 {  
    if(pos.X==45)
    pos.X=24;
    else
    pos.X =pos.X+7;
   SetConsoleCursorPosition( hConsole, pos );
 }
 if(key==115)
 {
  if(pos.Y==19)
  pos.Y=4;
  else
  pos.Y+=5;
  SetConsoleCursorPosition( hConsole, pos );
 }
 if(key==97)
 {
  if(pos.X==24)
  pos.X=45;
  else
  pos.X -=7;
  SetConsoleCursorPosition( hConsole, pos );
 }
 if(key==119)
 {
  if(pos.Y==4)
  pos.Y=19;
  else
  pos.Y -=5 ;
  SetConsoleCursorPosition( hConsole, pos );
 }
 if(key==27)
  {
   system("cls");
   int c=quit();
   if(c==1)
   goto q;
    else 
    exit(0);
  }
  
 if(key==13)
  {
   
      if(sum==0)
       {
       
        b=pos.X;
        c=pos.Y;
        trap(b,c);
        sum++;
        pos.X=70;
        pos.Y=16;
         SetConsoleCursorPosition( hConsole, pos );
         cout<<(++move);
         pos.X=b;
         pos.Y=c;
         SetConsoleCursorPosition( hConsole, pos );
        }
      else if(sum==1)
      {
        d=pos.X;
        e=pos.Y;
        trap(d,e);
        pos.X=70;
        pos.Y=16;
         SetConsoleCursorPosition( hConsole, pos );
         cout<<(++move);
         pos.X=d;
         pos.Y=e;
         SetConsoleCursorPosition( hConsole, pos );
        if((int)a[c%4][b%6]==(int)a[e%4][d%6])
         {
          win+=2;
          sum=0;
         }
         else
         {
          Sleep(500);
          if(((b==24||b==38)&&(c==4||c==14))||((b==31||b==45)&&(c==9||c==19)))
           drag(S,b,c);
          else
           drag(D,b,c);
           if(((d==24||d==38)&&(e==4||e==14))||((d==31||d==45)&&(e==9||e==19)))
           drag(S,d,e);
          else
           drag(D,d,e);
          sum=0;
          pos.X=d;
          pos.Y=e;
          SetConsoleCursorPosition( hConsole, pos );
         }    
   }
   }
 }while(win!=16);
 Sleep(1000);
 system("cls");
 won(); 
 system("cls");   
 nameinput();
 
 system("cls");
 moveinput();
 highscore();
  cout<<"\n\n\n\t\t\t\t EXIT  "<<(char)27;
  int ns;
  k:
  ns=getch();
  if(ns==13);
  else
  goto k;
  system("cls"); 
  system("color 0b");
 cout<<"\n\n\n\n\t\t\t\t THANK  YOU";
    cout<<"\n\t\t\t\t -----  ---\n";
    Sleep(3000);
    getch();
    return 0;
}
