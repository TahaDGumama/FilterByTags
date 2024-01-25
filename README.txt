FILTER BOOKS BY TAG

	You'll need .NET 7 for this coding test.

	Your input is the file books.csv containing list of books.
	The first line is the header and each line has 3 fields representing a book. Each books has: 
		Identifier	:		Book's number
		Title		:		Book's title
		Tags		:		A list of tags associated with the book, delimited by NewLine character (\n)

	Use CSVInputReader to read the csv file into DataTable.


	CONSTRAINTS:
		Do NOT use DataView class of .NET


	TODO: 
		Implement a solution that accept a list of tag, called A list, loaded from taglist.txt, give a list of books those contain AT LEAST 1 TAG in the A list.
		Example :
			BOOKS				TAGS
			How to...			Asia,Medical
			Man of the Match	Soccer, Sport
			HTTP Guide			Technical
			Tokyo				Asia,Japan

			Input Tag list: Asia,Sport

			Expected Output: 
				How to...
				Tokyo 
				Man of the match

		Store your ouput to {Your Name}.txt with each line as following format: "{Identifier}\t{Title}"

	
	HINTS:
		You can use LinQ and be mindful about OOP and SOLID