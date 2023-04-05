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
// setInterval((e) => {
//   Words.forEach((word) => {
//     for (let index = 0; index < Words.length; index++) {
//       word.nextElementSibling.classList.add("transform-words");
//       word.nextElementSibling.classList.remove("display-none");
//       word.classList.add("display-none");
//     }
//   });
//   clearInterval();
// }, 1000);

// function Test() {
//   let counter = Words.length;
//   Words.forEach((word) => {
//     for (let index = 0; index < Words.length; index++) {
//       if (word.nextElementSibling == null) {
//         Words[1].classList.add("transform-words");
//         // word.nextElementSibling.classList.add("display-none");
//       } else {
//         // word.previousElementSibling.classList.add("transform-words");
//         // word.nextElementSibling.classList.remove("display-none");
//         // word.classList.add("display-none");
//       }
//     }
//   });
// }
// setInterval(Test, 1000);

// Fade-in

// const professions = document.querySelectorAll(
//   ".stack-forteams__main__professions__profession"
// );
// const P = document.querySelectorAll(
//   ".stack-forteams__main__professions__profession > p"
// );
// professions.forEach((profession) => {
//   profession.addEventListener("click", (e) => {
//     e.preventDefault();
//     profession.classList.add("box");
//     P.forEach((p) => {
//       p.classList.remove("display-none");
//     });

//     professions.forEach((p) => {
//       p.classList.add("display-none");
//       p.classList.remove("box");
//     });
//   });
// });

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
// });
