import { Config } from '@abpdz/ng.core';

const baseUrl = '';

export const environment = {
  production: true,
  idleTime: 10 * 60 * 1000, // 10 minute
  application: {
    baseUrl,
    name: 'IDS_CLIENT',
    display: 'FREE TIME ',
    abrivation: 'FT',
    logoUrl: '',
  },
  notifications: {
    useSignalr: true,
  },
  oAuthConfig: {
    skipIssuerCheck: true,
    issuer: window.location.origin,
    redirectUri: window.location.origin,
    clientId: 'IDS_CLIENT_App',
    clientSecret: '1q2w3e*',
    scope: 'offline_access IDS_CLIENT',
    tokenUrl: '/connect/token',
    loginUrl: '/auth/login',
  },
  apis: {
    default: {
      url: '',
    },
  },
} as Config.Environment;
