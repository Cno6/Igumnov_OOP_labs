_Bool isInArea(double x, double y) {
	if ((x * x + y * y <= 1) || (x >= -1 && x < 0 && y >= -1 && y <= 1))
	{
		return ((x * x + y * y <= 1) || (x >= -1 && x < 0 && y >= -1 && y <= 1));
	}
	else
	{
		return 0;
	}
}

