// slider

let counter = 1;
setInterval(function () {
  document.getElementById("radio" + counter).checked = true;
  counter++;
  if (counter > 4) {
    counter = 1;
  }
}, 3000);

// Switch

const Words = document.querySelectorAll(".main-title__animation > span");
const parent = document.querySelectorAll(".main-title__animation");

// setInterval(() => {
//   for (let i = 0; i < Words.length; i++) {
//     Words[i].classList.add("display-none");
//     Words[i + 1].classList.remove("display-none");
//     Words[i + 1].classList.add("transform-words");
//   }
// }, 2000);

// setInterval(() => {
//   Words.forEach((word) => {
//     for (let index = 0; index < Words.length; index++) {
//       while (word.nextElementSibling !== null) {
//         word.nextElementSibling.classList.add("transform-words");
//         word.nextElementSibling.classList.remove("display-none");
//         word.classList.add("display-none");
//       }
//     }
//   });
//   // clearInterval();
// }, 2000);

// function Test() {
//   let counter = Words.length;
//   Words.forEach((word) => {
//     for (let index = 0; index < Words.length; index++) {
//       if (word.nextElementSibling == null) {
//         Words[1].classList.add("transform-words");
//         word.nextElementSibling.classList.add("display-none");
//       } else {
//         word.previousElementSibling.classList.add("transform-words");
//         word.nextElementSibling.classList.remove("display-none");
//         word.classList.add("display-none");
//       }
//     }
//   });
// }
// setInterval(Test, 1000);

// professions

const professions = document.querySelectorAll(
  ".stack-forteams__main__professions__all__profession"
);
const P = document.querySelectorAll(
  ".stack-forteams__main__professions__all__profession > p"
);

professions.forEach((profession) => {
  profession.addEventListener("click", (e) => {
    professions.forEach((p) => {
      if (p.classList.contains("box")) {
        p.classList.remove("box");
      }
    });
    e.preventDefault();
    profession.classList.add("box");
  });
});

// const icon = document.querySelector(".icon-sm");
// const navSearch = document.querySelector(".nav-search");

// icon.addEventListener("click", () => {
//   if (navSearch.classList.contains("d-none")) {
//     navSearch.classList.remove("d-none");
//     navSearch.classList.add("d-block");
//   } else {
//     navSearch.classList.remove("d-block");
//     navSearch.classList.add("d-none");
//   }

// //price

const switchButton = document.querySelector(
  ".stack-forteams__main__prices__all__switch--toggle--indicator"
);
const SpnSix = document.getElementById("spn-six");
const SpnTwelve = document.getElementById("spn-twelve");

switchButton.addEventListener("click", () => {
  if (SpnSix.innerText == 7) {
    switchButton.style.background = "#5dba7d";
    switchButton.style.setProperty("--pl", "22px");
    SpnSix.innerText = 6;
    SpnTwelve.innerText = 12;
  } else {
    switchButton.style.background = "#9fa6ad";
    switchButton.style.setProperty("--pl", "4px");
    SpnSix.innerText = 7;
    SpnTwelve.innerText = 14;
  }
});

//Fade-in

let texts = document.querySelectorAll(
  ".stack-forteams__main__features__all--feature"
);
let content = document.querySelector(".stack-forteams__main__features__all");

window.addEventListener("scroll", () => {
  for (let i = 0; i < texts.length; i++) {
    let contentPositionTop = texts[i].getBoundingClientRect().top;
    let contentPositionBottom = texts[i].getBoundingClientRect().bottom;
    let screenPosition = window.innerHeight / 1;

    if (contentPositionTop < screenPosition) {
      texts[0].classList.add("animation-fade-in");
    } else {
      texts[0].classList.remove("animation-fade-in");
    }
    setTimeout(() => {
      if (contentPositionTop < screenPosition) {
        texts[1].classList.add("animation-fade-in");
      } else {
        texts[1].classList.remove("animation-fade-in");
      }
    }, 1000);
    setTimeout(() => {
      if (contentPositionTop < screenPosition) {
        texts[2].classList.add("animation-fade-in");
      } else {
        texts[2].classList.remove("animation-fade-in");
      }
    }, 2000);
  }
});

// tiers

let cards = document.querySelectorAll(".tiers__cover");

window.addEventListener("scroll", () => {
  for (let i = 0; i < cards.length; i++) {
    let contentPosition = cards[i].getBoundingClientRect().top;
    let screenPosition = window.innerHeight / 1;

    if (contentPosition < screenPosition) {
      setTimeout(() => {
        cards[0].classList.add("anime-card");
      }, 1000);
      setTimeout(() => {
        cards[1].classList.add("anime-card");
      }, 2000);
      setTimeout(() => {
        cards[2].classList.add("anime-card");
      }, 3000);
      setTimeout(() => {
        cards[3].classList.add("anime-card");
      }, 4000);
    } else {
      cards[0].classList.remove("anime-card");
      cards[1].classList.remove("anime-card");
      cards[2].classList.remove("anime-card");
      cards[3].classList.remove("anime-card");
    }
  }
});
