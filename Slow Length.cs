int Len<T>(T[] array)
{
	int i = 1000;
	bool caught;
	while(true)
	{
		caught = false;
		try
		{
			T a = array[i];
		}
		catch(IndexOutOfRangeException)
		{
			i--;	
			caught = true;
		}
		if(!caught)			
			return i + 1;
	}
}