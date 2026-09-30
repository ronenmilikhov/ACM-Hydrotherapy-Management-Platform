const normalizeUrl = (url) => String(url ?? '').trim().replace(/\/+$/, '');

const resolveApiBaseUrl = () => {
  const explicitBaseUrl = normalizeUrl(process.env.EXPO_PUBLIC_API_BASE_URL);
  if (explicitBaseUrl) return explicitBaseUrl;

  // Replace this placeholder with the deployed AWS API URL, or set the Expo variable.
  return 'https://your-elastic-beanstalk-environment.example.com/api';
};

export const API_BASE_URL = resolveApiBaseUrl();

export const buildAuthHeaders = (token, baseHeaders = {}) => {
  const headers = { ...baseHeaders };
  const normalizedToken = String(token ?? '').trim();

  if (normalizedToken) {
    headers.Authorization = `Bearer ${normalizedToken}`;
  }

  return headers;
};

export const buildJsonAuthHeaders = (token) => buildAuthHeaders(token, {
  'Content-Type': 'application/json',
});
