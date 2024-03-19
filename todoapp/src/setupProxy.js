// setupProxy.js
const { createProxyMiddleware } = require('http-proxy-middleware');

module.exports = function(app) {
  app.use(
    '/api',  // The prefix of the URL that will be intercepted by the proxy
    createProxyMiddleware({
      target: 'http://localhost:5015', // The URL of your backend service
      changeOrigin: true, // Needed for virtual hosted sites
    })
  );
};