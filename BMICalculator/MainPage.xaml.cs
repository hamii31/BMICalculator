namespace BMICalculator
{
	public partial class MainPage : ContentPage
	{
		const double UnderweightTreshold = 18.5;
		const double NormalWeightTreshold = 24.9;
		const double OverweightTreshold = 29.9;
		public MainPage()
		{
			InitializeComponent();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			double weight = 0.0;
			double height = 0.0;

			if (double.TryParse(Weight.Text, out _))
			{
				weight = double.Parse(Weight.Text);
			}

			if (double.TryParse(Height.Text, out _))
			{
				height = double.Parse(Height.Text);
				height /= 100;
			}

			double imc = 0.0;

			if(weight == 0.0 || height == 0.0) // Checks if user has inputed the right values or any values at all
			{
			}
			else
			{
				imc = weight / (height * height);
			}

			string result = GetBMIResultMessage(imc);
			DisplayAlert("Result", result, "Ok");
		}
		
		private string GetBMIResultMessage(double imc)
		{
			if(imc == 0.0)
			{
				return "Are you sure you wrote your weight and height correctly?";
			}
			else if(imc < UnderweightTreshold)
			{
				return $"Your BMI is {imc:f2}. You are underweight. Consume more calories.";
			}
			else if(imc <= NormalWeightTreshold)
			{
				return $"Your BMI is {imc:f2}. Your weight is normal. Continue eating the same.";
			}
			else if(imc <= OverweightTreshold)
			{
				return $"Your BMI is {imc:f2}. You are overweight. Take caution with your feeding habits.";
			}
			else
			{
				return $"Your BMI is {imc:f2}. You are obese. Restrict daily intake of calories.";
			}
			
		}
	}
}