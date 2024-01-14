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

			double imc = weight / (height * height);

			BMI.Text = imc.ToString("F2");

			string result = GetBMIResultMessage(imc);
			DisplayAlert("Result", result, "Ok");
		}
		
		private string GetBMIResultMessage(double imc)
		{
			if(imc < UnderweightTreshold)
			{
				return "You are underweight. Consume more calories.";
			}
			else if(imc <= NormalWeightTreshold)
			{
				return "Your weight is normal. Continue eating the same.";
			}
			else if(imc <= OverweightTreshold)
			{
				return "You are overweight. Take caution with your feeding habits.";
			}
			else
			{
				return "You are obese. Restrict daily intake of calories.";
			}
			
		}
	}
}