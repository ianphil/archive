'use strict';

dragula([$('left-defaults'), $('right-defaults')]);


function clickHandler (e) {
  var target = e.target;
  if (target === sortable) {
    return;
  }
  target.innerHTML += ' [click!]';

  setTimeout(function () {
    target.innerHTML = target.innerHTML.replace(/ \[click!\]/g, '');
  }, 500);
}

function $ (id) {
  return document.getElementById(id);
}
