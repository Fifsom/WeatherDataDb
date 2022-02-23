using Core;



bool dbEmpty = Validate.IsDbEmpty();

if (dbEmpty)
{
    DbInteraction.PopulateDb();
}








