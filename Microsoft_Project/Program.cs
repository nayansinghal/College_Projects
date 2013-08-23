using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;
using System.Collections;
using System.Reflection;



namespace ConsoleApplication1
{

    class infix2postfix
        {

        string infix;
        List<string> Postfix_Token = new List<string>();
        List<string> Postfix_Type = new List<string>();
        List<int> Number_Of_Arguments = new List<int>();
        int pos;
        int size;

        const char LPAREN_CHAR = '(';
        const char RPAREN_CHAR = ')';
        const char MUL_CHAR = '*';
        const char DIV_CHAR = '/';
        const char POWER_CHAR = '^';
        const char CONCAT_CHAR = '.';
        const char PERCENT_CHAR = '%';
        const char EQOP_CHAR = '=';
        const char RANGE_CHAR = ':';
        const char MINUS_CHAR = '-';
        const char PLUS_CHAR = '+';
        const char LTOP_CHAR = '<';
        const char GTOP_CHAR = '>';

        string[] unary_operator = { "COS", "SIN", "TAN", "ACOS", "  ASIN", "ATAN", "COSH", "SINH", "TANH", "EXP", "LOG10", "SQRT", "ABS","POW","MAX","MIN","AND","OR"};
        string[] operators = { "+", "-", "*", "/", "%", "(", ")", "{", "}" ,"^","=",":","-","+","<",">",","};

        // function to retrieve function and variables token

        public void Getfunc_num(ref string pPs, ref string Token_type)
        {
            //Console.WriteLine("GETFUNCNUM");
            int  j;
            bool another = false;
            pos = pos - 1;
            //Console.WriteLine("function" + pos);
            while (pos < size)
            {
             
               bool flag = false;
               
                for (int i = 0; (i < unary_operator.Length) && !flag; i++)
                {
                    int k = pos;
                    for (j = 0; j < unary_operator[i].Length && k < size; j++)
                    {
                        if (infix[k] != unary_operator[i][j])
                        {
                            break;
                        }
                        else
                        {
                            k++;
                        }
                    }
                    if (j == unary_operator[i].Length)
                    {
                        if (another == false)
                        {
                            pPs = unary_operator[i];
                            Token_type = "FUNC";
                            pos = k;
                            flag = true;
                        }
                        else
                        {
                            
                            Token_type = "VARIABLE";
                            flag = true;
                        }
                    }
                }
                if (another == true)
                {
                    for (int i = 0; (i < operators.Length) && !flag; i++)
                    {
                        int k = pos;
                        for (j = 0; j < operators[i].Length && k < size; j++)
                        {
                            if (infix[k] != operators[i][j])
                            {
                                break;
                            }
                            else
                            {
                                k++;
                            }
                        }
                        if (j == operators[i].Length)
                        {
                                Token_type = "VARIABLE";
                                flag = true;
                        }
                    }
                }
                if(flag==false)
                {

                    pPs+=infix[pos];
                    pos++;
                    another = true ;
                }
                if(flag==true)
                {
                   // Console.WriteLine(pos);
                    return;
                }
            }
            if (another == true)
            {
                Token_type = "VARIABLE";
            }
        }
            
        // function to retrieve all tokens 
        public void GetToken(ref string pPs, ref string Token_Type,string Prev_Token_Type)
        {
           // Console.WriteLine("GETTOKEN");
            if (pos < size)
            {
                char s = infix[pos];
                pos++;
                if (s == ',')
                {
                    pPs = ",";
                    Token_Type = "NULL";
                    return;
                }
                switch (s)
                {
                    case LPAREN_CHAR:
                        Token_Type = "LPAREN";
                        pPs = s.ToString();
                        break;
                    case RPAREN_CHAR:
                        Token_Type = "RPAREN";
                        pPs = s.ToString();
                        break;

                    case MUL_CHAR:
                        Token_Type = "MUL";
                        pPs = "MUL";
                        break;

                    case DIV_CHAR:
                        Token_Type = "DIV";
                        pPs = "DIV";
                        break;

                    case POWER_CHAR:
                        Token_Type = "POWER";
                        pPs = s.ToString();
                        break;

                    case CONCAT_CHAR:
                        Token_Type = "CONCAT";
                        pPs = s.ToString();
                        break;

                    case PERCENT_CHAR:
                        Token_Type = "PERCENT";
                        pPs = s.ToString();
                        break;

                    case EQOP_CHAR:
                        Token_Type = "EQ";
                        pPs = s.ToString();
                        break;

                    case RANGE_CHAR:
                        Token_Type = "RANGE";
                        pPs = s.ToString();
                        break;

                    case MINUS_CHAR:
                    case PLUS_CHAR: //pPs = s.ToString();
                        if (Prev_Token_Type == "" || Prev_Token_Type == "LPAREN")
                        {
                            Token_Type = (s == MINUS_CHAR) ? "UMINUS" : "UPLUS";
                        }
                        else
                            Token_Type = (s == MINUS_CHAR) ? "MINUS" : "PLUS";
                        pPs = Token_Type;
                        break;
                        
                    case LTOP_CHAR:
                        if (infix[pos] == GTOP_CHAR)
                        {
                            Token_Type = "NE";
                            pPs = "NOT";
                            pos++;
                        }
                        else if (infix[pos] == EQOP_CHAR)
                        {
                            Token_Type = "LE";
                            pPs = "LE";
                            pos++;
                        }
                        else
                        {
                            Token_Type = "LT";
                            pPs = "LT";
                        }
                        break;
                    case GTOP_CHAR:
                        if (infix[pos] == EQOP_CHAR)
                        {
                            Token_Type = "GE";
                            pPs = "GE";
                            pos++;
                        }
                        else
                        {
                            Token_Type = "GT";
                            pPs = "GT";
                        }
                        break;
                    default:
                        Getfunc_num(ref pPs, ref Token_Type);
                        break;

                }
            }
        }

        //function to output token ,it's type and number of arguments it needed if it's not a function
        public void emit(ref string pPs, ref string Token_Type)
        {
            //Console.WriteLine("");
            Console.WriteLine(pPs + " " + Token_Type);
            Postfix_Token.Add(pPs);
            Postfix_Type.Add(Token_Type);
            if (Token_Type != "FUNC")
            {
                Number_Of_Arguments.Add(0);
            }

        }

        //function to read in next token

        public void match(ref string pPs, ref string Token_Type)
        {
            //Console.WriteLine("MATCH");
            pPs="";
            string Prev_Token_Type = Token_Type;
            Token_Type = "";
            GetToken(ref pPs, ref Token_Type,Prev_Token_Type);
            //Console.WriteLine(pPs + " " + Token_Type);
        }

        // function to parse a primary tree

        public void primary(ref string pPs, ref string Token_Type)
        {
            //Console.WriteLine("PRIMARY");
            switch (Token_Type)
            {
                case "LPAREN": 
                    match(ref pPs, ref Token_Type);
                    expression(ref pPs, ref Token_Type);
                    match(ref pPs, ref Token_Type);
                    //emit(ref pPs, ref Token_Type);
                    break;
                case "FUNC":
                    int count = 1;
                    string token = pPs;
                    string type = Token_Type;
                    match(ref pPs, ref Token_Type);
                    exprlist(ref pPs, ref Token_Type);
                    //Console.WriteLine(pPs);
                    while (true)
                    {
                        if (pPs == ",")
                        {
                            // Console.WriteLine(token);
                            // match(ref pPs, ref Token_Type);
                            //Console.WriteLine(pPs+" "+Token_Type);
                            exprlist(ref pPs, ref Token_Type);
                            count++;
                        }
                        else
                            break;
                    }
                    emit(ref token, ref type);
                    Number_Of_Arguments.Add(count);
                    break;
                case "VARIABLE":
                    emit(ref pPs, ref Token_Type);
                    match(ref pPs, ref Token_Type);
                    break;
            }
        }

        
        //parse level7 precedence unary +,-

        public void expr7(ref string pPs, ref string Token_Type)
        {
           // Console.WriteLine("EXPR7");
            string token = pPs;
            string type = Token_Type;
            if (Token_Type == "UMINUS" || Token_Type == "UPLUS")
                match(ref pPs, ref Token_Type);

            primary(ref pPs, ref Token_Type);
            if (type == "UMINUS")
            {
                emit(ref token, ref type);
            }
        }

        //parse level6 precedence ^

        public void expr6(ref string pPs, ref string Token_Type)
        {
            //Console.WriteLine("EXPR6");
            expr7(ref pPs, ref Token_Type);
            while (true)
            {
                if (Token_Type == "^")
                {
                    string token = pPs;
                    string type = Token_Type;
                    match(ref pPs, ref Token_Type);
                    expr7(ref pPs, ref Token_Type);
                    emit(ref token, ref type);
                }
                else
                    break;
            }
        }

        //parse level5 precedence *,/

        public void expr5(ref string pPs, ref string Token_Type)
        {
            //Console.WriteLine("EXPR5");
            expr6(ref pPs, ref Token_Type);
            while (true)
            {
                if (Token_Type == "MUL" || Token_Type == "DIV")
                {
                    string token = pPs;
                    string type = Token_Type;
                    match(ref pPs, ref Token_Type);
                    expr6(ref pPs, ref Token_Type);
                    emit(ref token, ref type);
                }
                else
                    break;
            }
        }

        //parse level4 precedence +,-

        public void expr4(ref string pPs, ref string Token_Type)
        {
            //Console.WriteLine("EXPR4");
            expr5(ref pPs, ref Token_Type);
            while (true)
            {
                if (Token_Type == "MINUS" || Token_Type == "PLUS")
                {
                    string token = pPs;
                    string type = Token_Type;
                    match(ref pPs, ref Token_Type);
                    expr5(ref pPs, ref Token_Type);
                    emit(ref token, ref type);
                }
                else
                    break;
            }
        }

        //parse level3 precedence .

        public void expr3(ref string pPs, ref string Token_Type)
        {
            //Console.WriteLine("EXPR3");
            expr4(ref pPs, ref Token_Type);
            while (true)
            {
                if (Token_Type == "CONCAT")
                {
                    string token = pPs;
                    string type = Token_Type;
                    match(ref pPs, ref Token_Type);
                    expr4(ref pPs, ref Token_Type);
                    emit(ref token, ref type);
                }
                else
                    break;
            }
        }

        //parse level2 precedence < , > ,<= ,>=

        public void expr2(ref string pPs, ref string Token_Type)
        {
          // Console.WriteLine("EXPR2");
            expr3(ref pPs, ref Token_Type);
            while (true)
            {
                if (Token_Type == "LT" || Token_Type == "GT" || Token_Type == "LE" || Token_Type == "GE")
                {
                    string token = pPs;
                    string type = Token_Type;
                    match(ref pPs, ref Token_Type);
                    expr3(ref pPs, ref Token_Type);
                    emit(ref token, ref type);
                }
                else
                    break;
            }
        }

        //parse level1 precedence = , <>

        public void expression(ref string pPs, ref string Token_Type)
        {
            //Console.WriteLine("EXPR");
            expr2(ref pPs, ref Token_Type);
            while (true)
            {
                if (Token_Type == "EQ" || Token_Type == "NE")
                {
                    string token = pPs;
                    string type = Token_Type;
                    match(ref pPs, ref Token_Type);
                    expr2(ref pPs, ref Token_Type);
                    emit(ref token, ref type);
                }
                else
                    break;
            }
        }

        //function to parse the expression

        public void exprlist(ref string pPs, ref string Token_Type)
        {

            match(ref pPs, ref Token_Type);
            //Console.WriteLine(pPs + " " + Token_Type + " ");
            expression(ref pPs, ref Token_Type);
            if (Token_Type == "RPAREN")
            {
                match(ref pPs,ref Token_Type);
            }
        }

        // main class from where the postfix starts

        public int  mainclass(List<string>token,List<string>type,List<int>number)
        {
            infix = Console.ReadLine();
            pos = 0;
            size = infix.Length;
            string pPs="";
            string Token_Type="";
            
            exprlist(ref pPs, ref Token_Type);
            int count = 0;
            foreach (string s in Postfix_Token )
            {
                token.Add(s);
                count++;
                //Console.WriteLine(s);
            }
            foreach (string Type in Postfix_Type)
            {
                type.Add(Type);
                //Console.WriteLine(Type);
            }
            foreach (int t in Number_Of_Arguments)
            {
                number.Add(t);
                Console.WriteLine(t);
            }
            return count;
        }

        }

    // class to write guide into ppt

    class FunctionGuide
    {
        Dictionary<string, int> track = new Dictionary<string, int>();
        int count;
         public FunctionGuide()
        { 
             // number of arguments each function take 

            track["SIN"] = 1;
            track["COS"] = 1;
            track["TAN"] = 1;
            track["ASIN"] = 1;
            track["ACOS"] = 1;
            track["ATAN2"] = 1;
            track["COSH"] = 1;
            track["SINH"] = 1;
            track["TANH"] = 1;
            track["MOD"] = 2;
            track["SQRT"] = 1;
            track["MAX"] = 2;
            track["MIN"] = 2;
            track["LOG10"] = 1;
            track["PLUS"] = 2;
            track["MINUS"] = 2;
            track["MUL"] = 2;
            track["DIV"] = 2;
            track["POW"] = 2;
            track["AND"] = 2;
            track["OR"] = 2;
            track["NOT"] = 1;
            track["UMINUS"] = 1;

        }

        // append the formula to xml document 

        public void Append(XmlElement _gdLst, string Name, string Formula , XmlElement _gd)
        {
            _gd.SetAttribute("name", Name);
            _gd.SetAttribute("fmla", Formula);
            _gdLst.AppendChild(_gd);
        }

        //guide for unary minus

        public string UMINUS(XmlDocument xmldoc, XmlElement _gdLst, string h)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "+-0 0 "  + h;
            Append(_gdLst, GuideName, Setformula, _gd0);
            return GuideName;
        }

        //guide for sin

        public string SIN(XmlDocument xmldoc, XmlElement _gdLst, string h)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "sin " + "1 " + h;
            Append(_gdLst, GuideName, Setformula, _gd0);
            return GuideName;
        }

        //guide for cos

        public string COS(XmlDocument xmldoc, XmlElement _gdLst,  string h)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "cos " + "1 " + h;
            Append(_gdLst, GuideName, Setformula, _gd0);
            return GuideName;
        }


        //guide for tan

        public string TAN(XmlDocument xmldoc, XmlElement _gdLst,  string h)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "tan " + "1 " + h;
            Append(_gdLst, GuideName, Setformula, _gd0);
            return GuideName;
        }

        //guide for asin

        public string ASIN(XmlDocument xmldoc, XmlElement _gdLst,  string h)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "*/" + h + " " + h + " 1";
            Append(_gdLst, GuideName, Setformula, _gd0);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd1 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " " + h + " 1";
            Append(_gdLst, GuideName, Setformula, _gd1);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd2 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " gd" + (count - 3).ToString() + " 1";
            Append(_gdLst, GuideName, Setformula, _gd2);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd3 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " gd" + (count - 4).ToString() + " 1";
            Append(_gdLst, GuideName, Setformula, _gd3);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd4 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 4).ToString() + " 1 6";
            Append(_gdLst, GuideName, Setformula, _gd4);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd5 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 4).ToString() + " 3 40";
            Append(_gdLst, GuideName, Setformula, _gd5);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd6 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 4).ToString() + " 5 112";
            Append(_gdLst, GuideName, Setformula, _gd6);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd7 = xmldoc.CreateElement("a:gd");
            Setformula = "+-gd" + (count - 4).ToString() + " " + h + " 0";
            Append(_gdLst, GuideName, Setformula, _gd7);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd8 = xmldoc.CreateElement("a:gd");
            Setformula = "+-gd" + (count - 4).ToString() + " gd" + (count - 2).ToString() + " 0";
            Append(_gdLst, GuideName, Setformula, _gd8);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd9 = xmldoc.CreateElement("a:gd");
            Setformula = "+-/gd" + (count - 4).ToString() + " gd" + (count - 2).ToString() + " 0";
            Append(_gdLst, GuideName, Setformula, _gd9);

            return GuideName;
        }

        //guide for acos

        public string ACOS(XmlDocument xmldoc, XmlElement _gdLst,  string h)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            // double x = h[0]-'0';
            double x = 0.95;
            double[] gd = new double[13];
            gd[0] = 31415926535898.0 * 1.0 / 10000000000000.0;
            Console.WriteLine(gd[0]);

            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            _gd0.SetAttribute("name", GuideName);
            _gd0.SetAttribute("fmla", "*/1 31415926535898 10000000000000");
            _gdLst.AppendChild(_gd0);

            gd[1] = gd[0] * 1.0 / 2.0;
            Console.WriteLine(gd[1]);
            string GuideName1 = "gd" + count.ToString();
            count++;
            XmlElement _gd1 = xmldoc.CreateElement("a:gd");
            string Setformula = "*/" + GuideName + " 1 2";
            Append(_gdLst, GuideName1, Setformula, _gd1);

            gd[2] = gd[1] + 0 - x;
            Console.WriteLine(gd[2]);

            GuideName = GuideName1;
            GuideName1 = "gd" + count.ToString();
            count++;
            XmlElement _gd2 = xmldoc.CreateElement("a:gd");
            Setformula = "+-" + GuideName + " 0 " + h;
            Append(_gdLst, GuideName1, Setformula, _gd2);

            gd[3] = x * x / 1.0;
            Console.WriteLine(gd[3]);

            GuideName = GuideName1;
            GuideName1 = "gd" + count.ToString();
            count++;
            XmlElement _gd3 = xmldoc.CreateElement("a:gd");
            Setformula = "*/" + h + " " + h + " 1";
            Append(_gdLst, GuideName1, Setformula, _gd3);

            gd[4] = gd[3] * x / 1.0;
            Console.WriteLine(gd[4]);

            GuideName = GuideName1;
            GuideName1 = "gd" + count.ToString();
            count++;
            XmlElement _gd4 = xmldoc.CreateElement("a:gd");
            Setformula = "*/" + GuideName + " " + h + " 1";
            Append(_gdLst, GuideName1, Setformula, _gd4);

            gd[5] = gd[4] * gd[3] / 1.0;
            Console.WriteLine(gd[5]);

            GuideName = GuideName1;
            GuideName1 = "gd" + count.ToString();
            count++;
            XmlElement _gd5 = xmldoc.CreateElement("a:gd");
            Setformula = "*/" + GuideName + " " + "gd" + ((count - 3).ToString()) + " 1";
            Append(_gdLst, GuideName1, Setformula, _gd5);

            gd[6] = gd[5] * gd[3] / 1.0;
            Console.WriteLine(gd[6]);

            GuideName = GuideName1;
            GuideName1 = "gd" + count.ToString();
            count++;
            XmlElement _gd6 = xmldoc.CreateElement("a:gd");
            Setformula = "*/" + GuideName + " " + "gd" + ((count - 4).ToString()) + " 1";
            Append(_gdLst, GuideName1, Setformula, _gd6);

            gd[7] = gd[4] * 1.0 / 6.0;
            Console.WriteLine(gd[7]);

            GuideName = GuideName1;
            GuideName1 = "gd" + count.ToString();
            count++;
            XmlElement _gd7 = xmldoc.CreateElement("a:gd");
            Setformula = "*/" + "gd" + ((count - 4).ToString()) + " 1 6";
            Append(_gdLst, GuideName1, Setformula, _gd7);

            gd[8] = gd[5] * 3.0 / 40.0;
            Console.WriteLine(gd[8]);

            GuideName = GuideName1;
            GuideName1 = "gd" + count.ToString();
            count++;
            XmlElement _gd8 = xmldoc.CreateElement("a:gd");
            Setformula = "*/" + "gd" + ((count - 4).ToString()) + " 3 40";
            Append(_gdLst, GuideName1, Setformula, _gd8);

            gd[9] = gd[6] * 5.0 / 112.0;
            Console.WriteLine(gd[9]);

            GuideName = GuideName1;
            GuideName1 = "gd" + count.ToString();
            count++;
            XmlElement _gd9 = xmldoc.CreateElement("a:gd");
            Setformula = "*/" + "gd" + ((count - 4).ToString()) + " 5 112";
            Append(_gdLst, GuideName1, Setformula, _gd9);

            gd[10] = gd[7] + gd[8] - 0;
            Console.WriteLine(gd[10]);

            GuideName = GuideName1;
            GuideName1 = "gd" + count.ToString();
            count++;
            XmlElement _gd10 = xmldoc.CreateElement("a:gd");
            Setformula = "+-" + "gd" + ((count - 4).ToString()) + " gd" + ((count - 3).ToString()) + " 0";
            Append(_gdLst, GuideName1, Setformula, _gd10);

            gd[11] = gd[10] + gd[9] - 0;
            Console.WriteLine(gd[11]);

            GuideName = GuideName1;
            GuideName1 = "gd" + count.ToString();
            count++;
            XmlElement _gd11 = xmldoc.CreateElement("a:gd");
            Setformula = "+-" + GuideName + " gd" + ((count - 3).ToString()) + " 0";
            Append(_gdLst, GuideName1, Setformula, _gd11);

            gd[12] = gd[2] + 0 - gd[11];
            Console.WriteLine(gd[12]);

            GuideName = GuideName1;
            GuideName1 = "gd" + count.ToString();
            count++;
            XmlElement _gd12 = xmldoc.CreateElement("a:gd");
            Setformula = "+-" + "gd" + ((count - 11).ToString()) + " 0 " + GuideName;
            Append(_gdLst, GuideName1, Setformula, _gd12);
            Console.WriteLine(gd[12]);

            return GuideName1;
        }

        //guide for atan2

        public string ATAN2(XmlDocument xmldoc, XmlElement _gdLst, string h)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "at2 " + "1 " + h;
            Append(_gdLst, GuideName, Setformula, _gd0);

            return GuideName;
        }

        //guide for Cosh

        public string COSH(XmlDocument xmldoc, XmlElement _gdLst,  string h)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "*/" + h + " " + h + " 1";
            Append(_gdLst, GuideName, Setformula, _gd0);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd1 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " gd" + (count - 2).ToString() + " 1";
            Append(_gdLst, GuideName, Setformula, _gd1);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd2 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " gd" + (count - 3).ToString() + " 1";
            Append(_gdLst, GuideName, Setformula, _gd2);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd3 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 4).ToString() + " 1 2";
            Append(_gdLst, GuideName, Setformula, _gd3);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd4 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 4).ToString() + " 1 24";
            Append(_gdLst, GuideName, Setformula, _gd4);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd5 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 4).ToString() + " 1 720";
            Append(_gdLst, GuideName, Setformula, _gd5);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd6 = xmldoc.CreateElement("a:gd");
            Setformula = "+-gd" + (count - 4).ToString() + " 1 0";
            Append(_gdLst, GuideName, Setformula, _gd6);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd7 = xmldoc.CreateElement("a:gd");
            Setformula = "+-gd" + (count - 2).ToString() + " gd" + (count - 4).ToString() + " 0";
            Append(_gdLst, GuideName, Setformula, _gd7);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd8 = xmldoc.CreateElement("a:gd");
            Setformula = "+-gd" + (count - 2).ToString() + " gd" + (count - 4).ToString() + " 0";
            Append(_gdLst, GuideName, Setformula, _gd8);

            return GuideName;
        }

        //guide for sinh

        public string SINH(XmlDocument xmldoc, XmlElement _gdLst,  string h)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "*/" + h + " " + h + " 1";
            Append(_gdLst, GuideName, Setformula, _gd0);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd1 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " " + h + " 1";
            Append(_gdLst, GuideName, Setformula, _gd1);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd2 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " gd" + (count - 3).ToString() + " 1";
            Append(_gdLst, GuideName, Setformula, _gd2);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd3 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " gd" + (count - 4).ToString() + " 1";
            Append(_gdLst, GuideName, Setformula, _gd3);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd4 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 4).ToString() + " 1 6";
            Append(_gdLst, GuideName, Setformula, _gd4);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd5 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 4).ToString() + " 1 60";
            Append(_gdLst, GuideName, Setformula, _gd5);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd6 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 4).ToString() + " 1 5040";
            Append(_gdLst, GuideName, Setformula, _gd6);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd7 = xmldoc.CreateElement("a:gd");
            Setformula = "+-gd" + (count - 4).ToString() + " " + h + " 0";
            Append(_gdLst, GuideName, Setformula, _gd7);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd8 = xmldoc.CreateElement("a:gd");
            Setformula = "+-gd" + (count - 4).ToString() + " gd" + (count - 2).ToString() + " 0";
            Append(_gdLst, GuideName, Setformula, _gd8);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd9 = xmldoc.CreateElement("a:gd");
            Setformula = "+-/gd" + (count - 4).ToString() + " gd" + (count - 2).ToString() + " 0";
            Append(_gdLst, GuideName, Setformula, _gd9);

            return GuideName;
        }

        //guide for Tanh

        public string TANH(XmlDocument xmldoc, XmlElement _gdLst,  string h)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "*/" + h + " " + h + " 1";
            Append(_gdLst, GuideName, Setformula, _gd0);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd1 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " " + h + " 1";
            Append(_gdLst, GuideName, Setformula, _gd1);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd2 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " gd" + (count - 3).ToString() + " 1";
            Append(_gdLst, GuideName, Setformula, _gd2);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd3 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " gd" + (count - 4).ToString() + " 1";
            Append(_gdLst, GuideName, Setformula, _gd3);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd4 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 4).ToString() + " 1 3";
            Append(_gdLst, GuideName, Setformula, _gd4);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd5 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 4).ToString() + " 2 15";
            Append(_gdLst, GuideName, Setformula, _gd5);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd6 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 4).ToString() + " 17 315";
            Append(_gdLst, GuideName, Setformula, _gd6);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd7 = xmldoc.CreateElement("a:gd");
            Setformula = "+-" + h + " 0 gd" + (count - 4).ToString();
            Append(_gdLst, GuideName, Setformula, _gd7);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd8 = xmldoc.CreateElement("a:gd");
            Setformula = "+-gd" + (count - 2).ToString() + " gd" + (count - 4).ToString() + " gd" + (count - 3).ToString();
            Append(_gdLst, GuideName, Setformula, _gd8);

            return GuideName;

        }

        //guide for Modulus 

        public string MOD(XmlDocument xmldoc, XmlElement _gdLst, string a, string b)
        {
            int a1 = 5, b1 = 3;
            int[] gd = new int[3];

            gd[0] = a1 * 1 / b1;

            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "*/" + a + " 1 " + b;
            Append(_gdLst, GuideName, Setformula, _gd0);

            gd[1] = gd[0] * b1 / 1;
            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd1 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " " + b + " 1";
            Append(_gdLst, GuideName, Setformula, _gd1);

            gd[2] = a1 + 0 - gd[1];
            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd2 = xmldoc.CreateElement("a:gd");
            Setformula = "+-" + a + " 0 " + " gd" + (count - 2).ToString();
            Append(_gdLst, GuideName, Setformula, _gd2);
            Console.WriteLine(gd[2]);

            return GuideName;
        }

        //guide for sqrt

        public string SQRT(XmlDocument xmldoc, XmlElement _gdLst,  string a)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "sqrt " + a;
            Append(_gdLst, GuideName, Setformula, _gd0);

            return GuideName;
        }

        //guide for max

        public string MAX(XmlDocument xmldoc, XmlElement _gdLst,  string[] a)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "max " + a[0] + " " + a[1];
            Append(_gdLst, GuideName, Setformula, _gd0);

            for (int i = 2; i < a.Length; i++)
            {
                string GuideName1 = "gd" + count.ToString();
                count++;
                XmlElement _gd1 = xmldoc.CreateElement("a:gd");
                string Setformula1 = "max " + a[i] + " " + GuideName;
                Append(_gdLst, GuideName1, Setformula1, _gd1);
                GuideName = GuideName1;
            }

            return GuideName;
        }

        //guide for min

        public string MIN(XmlDocument xmldoc, XmlElement _gdLst, string[] a)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "min " + a[0] + " " + a[1];
            Append(_gdLst, GuideName, Setformula, _gd0);

            for (int i = 2; i < a.Length; i++)
            {
                string GuideName1 = "gd" + count.ToString();
                count++;
                XmlElement _gd1 = xmldoc.CreateElement("a:gd");
                string Setformula1 = "min " + a[i] + " " + GuideName;
                Append(_gdLst, GuideName1, Setformula1, _gd1);
                GuideName = GuideName1;
            }

            return GuideName;
        }

        //guide for log

        public string LOG(XmlDocument xmldoc, XmlElement _gdLst,  string a)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "+-" + a + " 0 1";
            Append(_gdLst, GuideName, Setformula, _gd0);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd1 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " gd" + (count - 2).ToString() + " 1";
            Append(_gdLst, GuideName, Setformula, _gd1);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd2 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " gd" + (count -3).ToString() + " 2";
            Append(_gdLst, GuideName, Setformula, _gd2);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd3 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " gd" + (count - 4).ToString() + " 3";
            Append(_gdLst, GuideName, Setformula, _gd3);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd4 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " gd" + (count - 5).ToString() + " 4";
            Append(_gdLst, GuideName, Setformula, _gd4);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd5 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " gd" + (count - 6).ToString() + " 5";
            Append(_gdLst, GuideName, Setformula, _gd5);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd6 = xmldoc.CreateElement("a:gd");
            Setformula = "*/gd" + (count - 2).ToString() + " gd" + (count - 7).ToString() + " 6";
            Append(_gdLst, GuideName, Setformula, _gd6);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd7 = xmldoc.CreateElement("a:gd");
            Setformula = "+-gd" + (count - 8).ToString() + " gd" + (count - 5).ToString() + " gd" + (count - 6).ToString();
            Append(_gdLst, GuideName, Setformula, _gd7);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd8 = xmldoc.CreateElement("a:gd");
            Setformula = "+-gd" + (count - 5).ToString() + " gd" + (count - 3).ToString() + " gd" + (count - 4).ToString();
            Append(_gdLst, GuideName, Setformula, _gd8);

            GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd9 = xmldoc.CreateElement("a:gd");
            Setformula = "+-gd" + (count - 3).ToString() + " 0" +  " gd" + (count - 2).ToString();
            Append(_gdLst, GuideName, Setformula, _gd9);

            return GuideName;
        }   

        //guide for log10

        public string LOG10(XmlDocument xmldoc, XmlElement _gdLst, string a)
        {
            LOG(xmldoc, _gdLst, a);
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "*/gd" + (count - 2).ToString() + " 1 2.3025850929940456840179914546844";
            Append(_gdLst, GuideName, Setformula, _gd0);

            return GuideName;
        }

        //guide for Plus
        public string PLUS(XmlDocument xmldoc, XmlElement _gdLst, string a, string b)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "+-" + a + " "+ b + " 0";
            Append(_gdLst, GuideName, Setformula, _gd0);

            return GuideName;
        }

        //guide for Minus

        public string MINUS(XmlDocument xmldoc, XmlElement _gdLst, string a, string b)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "+-" + a + " 0 " + b;
            Append(_gdLst, GuideName, Setformula, _gd0);

            return GuideName;
        }

        //guide for Multiply

        public string MUL(XmlDocument xmldoc, XmlElement _gdLst, string a, string b)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "*/" + a + " " + b +" 1" ;
            Append(_gdLst, GuideName, Setformula, _gd0);

            return GuideName;
        }

        //guide for Divide

        public string DIV(XmlDocument xmldoc, XmlElement _gdLst,  string a, string b)
        {
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "*/" + a + " 1 " + b;
            Append(_gdLst, GuideName, Setformula, _gd0);

            return GuideName;
        }

        //guide for pow

        public string POW(XmlDocument xmldoc, XmlElement _gdLst,  string a, string b)
        {
            int i,power=0;
            bool flag = false;
            for(i=0;i<b.Length;i++)
            {
                if (!(b[i] >= '0' && b[i] <= '9'))
                {
                    flag = true;
                    break;
                }
                power = power*10 + (b[i] - '0');
                
            }
            
            if (flag == false)
            {
               // Console.WriteLine(flag);
                //Console.WriteLine(power);
                string GuideName1 = "gd" + count.ToString();
                count++;
                string h = a;
                XmlElement _gd2 = xmldoc.CreateElement("a:gd");
                string Setformula1 = "*/1 1 1";
                //Console.WriteLine(power);
                Append(_gdLst, GuideName1, Setformula1, _gd2);
                while (power != 0)
                {
                    Console.WriteLine(power);
                    if (power % 2 != 0)
                    {
                        string GuideName2 = "gd" + count.ToString();
                        count++;
                        XmlElement _gd3 = xmldoc.CreateElement("a:gd");
                        Setformula1 = "*/" + GuideName1 + " " + h +" 1";
                        Append(_gdLst, GuideName2, Setformula1, _gd3);
                        GuideName1 = GuideName2;
                    }
                    string GuideName3 = "gd" + count.ToString();
                    count++;
                    XmlElement _gd4 = xmldoc.CreateElement("a:gd");
                    Setformula1 = "*/" + h + " " + h + " 1";
                    Append(_gdLst, GuideName3, Setformula1, _gd4);
                    h = GuideName3;
                    power /= 2;
                }
                Console.WriteLine(GuideName1);
                return GuideName1;
            }
            return "wrong";    //if b is not integer
            
        }

        //guide for AND

        public string AND(XmlDocument xmldoc, XmlElement _gdLst,  string[] a)
        {
            int l = a.Length;
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "?:" + a[0] + " 1 0" ;
            Append(_gdLst, GuideName, Setformula, _gd0);

            for (int i = 1; i < l; i++)
            {
               GuideName = "gd" + count.ToString();
                count++;
                XmlElement _gd1 = xmldoc.CreateElement("a:gd");
                Setformula = "?:" + a[i] + " gd" + (count-2).ToString()+ " 0";
                Append(_gdLst, GuideName, Setformula, _gd1);
            }

            return GuideName;
        }


        //guide for OR

        public string OR(XmlDocument xmldoc, XmlElement _gdLst,  string[] a)
        {
            int l = a.Length;
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "?:" + a[0] + " 1 0";
            Append(_gdLst, GuideName, Setformula, _gd0);

            for (int i = 1; i < l; i++)
            {
                GuideName = "gd" + count.ToString();
                count++;
                XmlElement _gd1 = xmldoc.CreateElement("a:gd");
                Setformula = "?:" + a[i] + " 1 gd" + (count - 2).ToString();
                Append(_gdLst, GuideName, Setformula, _gd1);
            }

            return GuideName;
        }

        //guide for NOT

        public string NOT(XmlDocument xmldoc, XmlElement _gdLst,  string a)
        {
            int l = a.Length;
            string GuideName = "gd" + count.ToString();
            count++;
            XmlElement _gd0 = xmldoc.CreateElement("a:gd");
            string Setformula = "?:" + a + " 0 1";
            Append(_gdLst, GuideName, Setformula, _gd0);

            return GuideName;
        }

        
        
        // function to write guide after getting postfix order

        public void nayan(XmlDocument xmldoc, XmlElement _gdLst, string[] token,string[] type,int[] Number_Of_Arguments)
        {
            
            count = 0;
            Stack st = new Stack();
            int j = 1,l=token.Length;
            for (j = 0; j < l;j++)
            {
                //Console.WriteLine(j++);
                if (type[j] == "VARIABLE")
                {
                    st.Push(token[j]);
                    Console.WriteLine(token[j]);
                }
                else
                {
                    Console.WriteLine(token[j]);
                    Type myTypeObj = this.GetType();
                    MethodInfo myMethodInfo = myTypeObj.GetMethod(token[j]);
                    

                    if (token[j] != "AND" && token[j] != "OR" &&token[j]!="MAX" && token[j]!="MIN")
                    {
                        int number = ((track[token[j]] > Number_Of_Arguments[j]) ? track[token[j]] : Number_Of_Arguments[j]);
                        int t = 2 + number ;
                        Console.WriteLine(number);
                        object[] obj = new object[t];
                        obj[0] = xmldoc;
                        obj[1] = _gdLst;
                        for (int i = number - 1; i >= 0; i--)
                        {
                            obj[2 + i] = st.Peek();
                            // Console.WriteLine(st.Peek());
                            st.Pop();
                        }
                        string gd = (string)myMethodInfo.Invoke(this, obj);
                        st.Push(gd);
                    }
                    else
                    {
                        int t = 2 + 1;
                        int number=((track[token[j]] > Number_Of_Arguments[j]) ? track[token[j]] : Number_Of_Arguments[j]);
                        Console.WriteLine(number);
                        object[] obj = new object[t];
                        obj[0] = xmldoc;
                        obj[1] = _gdLst;
                        Console.WriteLine("NAYAN: AND");
                        string[] And_object = new string[((track[token[j]] > Number_Of_Arguments[j]) ? track[token[j]] : Number_Of_Arguments[j])];
                        for (int i = number - 1; i >= 0; i--)
                        {
                            And_object[i] = st.Peek().ToString();
                            st.Pop();
                        }
                        obj[2] = And_object;
                        string gd = (string)myMethodInfo.Invoke(this, obj);
                        st.Push(gd);
                    }
                }
            }
            

        }
        
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            List<string> postfix_token = new List<string>();
            List<string> postfix_type = new List<string>();
            List<int> Number_Of_Arguments = new List<int>();

            infix2postfix infix=new infix2postfix();
            int t=infix.mainclass(postfix_token,postfix_type,Number_Of_Arguments);

           

            Dictionary<string, int> track = new Dictionary<string, int>();
            track["Add"] = 1;
           
            //string m_nameSpace = "http://schemas.openxmlformats.org/presentationml/2006/main";
            string m_nameSpaceDrawing = "http://schemas.openxmlformats.org/drawingml/2006/main";
            //string m_nameSpaceRel = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";

            XmlDocument xmldoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            //XmlElement xmlelem2;
            XmlText xmltext;
            xmldoc=new XmlDocument();

            //let's add the XML declaration section

            xmlnode=xmldoc.CreateNode(XmlNodeType.XmlDeclaration,"","");
            xmldoc.AppendChild(xmlnode);

            //let's add the root element

            xmlelem=xmldoc.CreateElement("ROOT");
            xmltext=xmldoc.CreateTextNode("This is the text of the root element");
            xmldoc.AppendChild(xmlelem);
            xmlelem.AppendChild(xmltext);

            XmlElement _lineTo = xmldoc.CreateElement("a:lnTo", m_nameSpaceDrawing);
            xmlelem.AppendChild(_lineTo);

            XmlElement _lineToPt = xmldoc.CreateElement("a:pt", m_nameSpaceDrawing);
            _lineTo.AppendChild(_lineToPt);
            _lineToPt.SetAttribute("x", "23");
            _lineToPt.SetAttribute("y", "34");

            //let's add another element (child of the root)

            XmlElement _avLst=xmldoc.CreateElement("a:avLst");
            xmlelem.AppendChild(_avLst);

            XmlElement _gdLst = xmldoc.CreateElement("a:gdLst");
            _avLst.AppendChild(_gdLst);

            var tokens = new Dictionary<string, string>();

            FunctionGuide f = new FunctionGuide();
            
            string[] token=new string[t];
            string[] type = new string[t];
            int[] number = new int[t];

            for(int i = 0; i < t ; i++)
            {
                //Console.WriteLine(i);
                token[i] = postfix_token[i];
                type[i] = postfix_type[i];
                number[i] = Number_Of_Arguments[i];
            }
            

            f.nayan(xmldoc, _gdLst, token,type,number);

            
            //let's try to save the XML document in a file: C:\pavel.xml
            try
            {
            xmldoc.Save("D:\\pavel.xml"); //I've chosen the c:\ for the resulting file pavel.xml
            }
            catch (Exception e)
            {
            Console.WriteLine(e.Message);
            }
            Console.ReadLine();
            
        }
    }
}
