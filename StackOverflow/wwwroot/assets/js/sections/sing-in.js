let bg = document.querySelector(".sign-in__left");

let images = [];

images.push(
  "https://i.pinimg.com/736x/7f/98/02/7f9802af9537f3231ba27012c0ae6b7d.jpg"
);
images.push(
  "https://img.favpng.com/15/14/13/manager-management-free-content-clip-art-png-favpng-BWmN8h0wnwLfX9xyVn3kRnw4J.jpg"
);
images.push(
  "http://www.clker.com/cliparts/6/b/f/8/1516154399687998636clipart-administrative-assistant-day.hi.png"
);
images.push(
  "https://www.jing.fm/clipimg/detail/248-2488688_marketing-clipart-business-management-administration-finance-literacy.png"
);



window.onload = function () {
  const random = Math.floor(Math.random() * images.length);

  bg.style.backgroundImage = `url(${images[random]})`;
};
