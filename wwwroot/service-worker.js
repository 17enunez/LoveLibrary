// Install event
self.addEventListener('install', (event) => {
    console.log('Service Worker installing...');
    // Skip waiting so the new service worker activates immediately
    self.skipWaiting();
});

// Activate event
self.addEventListener('activate', (event) => {
    console.log('Service Worker activating...');
    return self.clients.claim();
});

// Fetch event - optional caching
self.addEventListener('fetch', (event) => {
    // You can add caching here later if you want offline support
    console.log('Fetching:', event.request.url);
});