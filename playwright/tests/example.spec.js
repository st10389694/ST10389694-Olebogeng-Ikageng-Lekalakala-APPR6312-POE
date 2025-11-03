const { test, expect } = require('@playwright/test');

test('basic claim flow', async ({ page }) => {
  // replace with your dev url
  await page.goto('http://localhost:5000');
  await expect(page).toHaveTitle(/GiftOfGivers/);
});
