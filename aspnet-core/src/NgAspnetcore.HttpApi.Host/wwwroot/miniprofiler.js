setTimeout(() => {
    console.log(`/^((?!/profiler/results).)*$/`);
    const s = document.createElement('script');
    s.setAttribute('src', '/profiler/includes.min.js');
    s.setAttribute('id', 'mini-profiler');
    s.setAttribute('async', 'async');
    s.setAttribute('data-path', '/profiler/');
    s.setAttribute('data-ids', '');
    s.setAttribute('data-current-id', '');
    s.setAttribute('data-position', 'BottomLeft');
    s.setAttribute('data-scheme', 'Auto');
    s.setAttribute('data-authorized', 'true');
    s.setAttribute('data-controls', 'true');
    s.setAttribute('data-children', 'true');
    // s.setAttribute('data-trivial', 'true');
    s.setAttribute('data-max-traces', '16');
    s.setAttribute('data-toggle-shortcut', 'Alt+P');
    s.setAttribute('data-trivial-milliseconds', '2.0');
    s.setAttribute(
      'data-ignored-duplicate-execute-types',
      'Open,OpenAsync,Close,CloseAsync'
    );
    document.body.appendChild(s);
  }, 800);
  function makeMiniProfilerRequests(headers) {
    const miniProfilerHeaders = headers.getAll('x-miniprofiler-ids');
  
    if (!miniProfilerHeaders) {
      return;
    }
  
    miniProfilerHeaders.forEach((miniProfilerIdHeaderValue) => {
      const ids = JSON.parse(miniProfilerIdHeaderValue);
      window.MiniProfiler.fetchResults(ids);
    });
  }
  