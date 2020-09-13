# MarketFinance C# Backend Coding Exercise

## Top 5 main areas of concern:

1. `SubmitApplicationFor` method is quite big, complex and does too many stuff inside. If we would add new `IProduct` implementation in the future, this method also become bigger and more complex.
We can refactor `ProductApplicationService` service using Visitor pattern in aim to break this method into multiple little methods and make this service flexible for the upcoming features (for example, new type of `IProduct`)

2. Returning just int value from `SubmitApplicationFor` method looks very strange. 
It says nothing about returning value - i cant understand if it is a id of application or any other number (sum or something like that). 
Also retrieving value of `SubmitApplicationFor` method is strange too. We can see that method returns same values in cases of unsuccessful results and missing of `result.ApplicationId`. 
We can refactor `SubmitApplicationFor` method signature by returning result object from this method, for example, `ISubmitApplicationResult`, which contains `ApplicationId`, message of error or exception, and other useful info.

3. Throwing exceptions is making applications slow enough to make it worth avoiding them in normal use. 
After updating `SubmitApplicationFor` method signature and using Visitor pattern there is no need to throw exception like this.

4. There are no arguments validation in service methods. 

5. It would be great to have XML descriptions of class properties and methods. `ProductApplicationService` service can be used in some library of a company, which can be used by other engineers in others projects. So it would be very helpful, clear to have documentation of library classes.
