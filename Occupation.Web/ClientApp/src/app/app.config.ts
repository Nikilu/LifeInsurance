export class AppConfig {
  public static endpoint = {
    occupations: `/occupation`,
    occupationFactor: `/occupation/{occupationId}/rating-factor`,
    yearlyPremium: `/premium/death/yearly`,
  };
}
