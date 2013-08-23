#include<iostream>
#include<map>
#include<algorithm>
#include<string>
#include<fstream>
#include<vector>
using namespace std;

//lowercase the character or replace it by '-'
char FilterNonAlphabetic(char& letter) 
{
	if (isalpha(letter)) 
	{ 
		return tolower(letter); 
	}
	return '-';
}

// function to sort pair using second value
bool SortByWeight(const pair<string, int>& left, const pair<string, int>& right)
{
	return left.second < right.second;
}

//load the database file and maintain a dictionary
void load_file(map<string, int>& dictionary)
{
	ifstream fin;
	fin.open("database.txt");
	fin.seekg(0 , ios::end);
	int length = fin.tellg();
	fin.seekg(0 , ios::beg);
	
	string line(length , '0');
	fin.read(&line[0] , length);
	
	transform(line.begin(), line.end(), line.begin(), FilterNonAlphabetic);

		string::size_type end = line.size();

		for (string::size_type i = 0;;) {
			while (line[++i] == '-' && i < end); //find first '-' character

			if (i >= end) { break; }

			string::size_type begin = i;
			while (line[++i] != '-' && i < end); //find first not of '-' character

			dictionary[line.substr(begin, i - begin)]++;
		}	
}

//edit the word -deletion, transposition, alteration, insertion
void edit(string& word , vector<string>& result)
{
	for (int i = 0;i < word.size();i++) result.push_back(word.substr(0, i)+ word.substr(i + 1)); //deletions
		for (int i = 0;i < word.size() - 1;i++) result.push_back(word.substr(0, i) + word[i+1] + word.substr(i + 2)); //transposition

		for (char j = 'a';j <= 'z';++j) {
			for (int i = 0;i < word.size();i++) result.push_back(word.substr(0, i) + j + word.substr(i + 1)); //alterations
			for (int i = 0;i < word.size() + 1;i++) result.push_back(word.substr(0, i) + j + word.substr(i)     ); //insertion
		}
}

//assign weight to result obtained after editing
void weight(vector<string>& result, map<string, int>& intermediate_result, map<string, int>& dictionary)
{
	int position,end = dictionary.size();
	for(int i = 0;i < result.size(); i++)
	{
		if(dictionary[result[i]] != 0)
		intermediate_result[result[i]] = dictionary[result[i]];
	}
}

//check whether word exists in a dictionary or not.
//If not, then edit the word and return the maximum weight word or edit once again
string check(string& word,map<string, int>& dictionary)
{
	vector<string>result;
	if(dictionary.find(word) != dictionary.end())return word;
	
	edit(word , result);
	
	map<string, int>intermediate_result;
	weight(result, intermediate_result, dictionary);
	
	if(intermediate_result.size() > 0)
	return max_element(intermediate_result.begin(), intermediate_result.end(), SortByWeight)->first;
	
	
	for(int i = 0 ;i < result.size(); i++)
	{
		vector<string>second_edit;
		edit(result[i] , second_edit);
		weight(second_edit , intermediate_result , dictionary);	
	}
	
	if(intermediate_result.size() > 0)
	return max_element(intermediate_result.begin(), intermediate_result.end(), SortByWeight)->first;
	
	return "";
}

//main function
int main()
{
	map<string, int>dictionary;
	load_file(dictionary);
	
	string word,answer;
	
	while(word!="quit")
	{
	cout<<"Enter word :";
	cin>>word;
	answer=check(word , dictionary);
	
	if(answer!="")
		cout<<"Correct Word is "<<answer<<"\n\n";
	else
		cout<<"No Correct Word is available \n\n"; 
	}
}
