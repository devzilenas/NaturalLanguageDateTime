# NaturalLanguageDateTime
Natural language date time expression parse in c#

## Usage notes
```c#
using NaturalLanguageDateTime.NLDT;

DateTime yesterday = NLDateTime.Evaluate("yesterday").DateTime;
DateTime today = NLDateTime.Evaluate("today").DateTime;
DateTime tomorrow = NLDateTime.Evaluate("tomorrow").DateTime;
DateTime past = NLDateTime.Evaluate("past").DateTime;
DateTime future = NLDateTime.Evaluate("future").DateTime;
DateTime dt1 = NLDateTime.Evaluate("1 day afted today").DateTime;
DateTime dt2 = NLDateTime.Evaluate("1 week after tomorrow").DateTime;
DateTime dt3 = NLDateTime.Evaluate("1 day after tomorrow").DateTime;
DateTime dt4 = NLDateTime.Evaluate("1 day before today").DateTime;
DateTime dt5 = NLDateTime.Evaluate("day after tomorrow").DateTime;
DateTime dt6 = NLDateTime.Evaluate("1 week after tomorrow").DateTime;
DateTime dt7 = NLDateTime.Evaluate("some day after tomorrow").DateTime;
DateTime dt8 = NLDateTime.Evaluate("the day after tomorrow").DateTime;
DateTime dt9 = NLDateTime.Evaluate("two months ago");
DateTime datetime = DTime.DateTime;

```
