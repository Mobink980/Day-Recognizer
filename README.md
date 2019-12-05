# Day-Recognizer
A program to seperate the given time intervals into days written in C#.
<p>This program takes an array of intervals and returns an arraylist which contains the first and last hour of a day as one of its elements.</p>
<p>The program works as the following:</p>
<p>
We have an ArrayList that could have from 1 to 4 (n + 1) items: <br>
  <br>
"1, 07:00,08:00"<br>
"2, 08:00,00:00"<br>
                 -------------> Right here the day changes<br>
"0, 00:00,06:00"<br>
"1, 06:00,06:59" <br>
<br>
==============================     <br>           
 So we need an ArrayList with these two items. <br>
  <br>
"07:00,00:00"<br>
                 -------------> Right here the day changes<br>
"00:00,06:59"<br>
</p>
