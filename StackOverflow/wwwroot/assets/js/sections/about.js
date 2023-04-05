// nav about

const nav = document.querySelector(".nav");

const ourProducts = document.getElementById("our-products");

const ourCompany = document.getElementById("our-company");
const followUs = document.getElementById("follow-us");

const productsToggle = document.getElementById("right-toggle");
const companyToggle = document.getElementById("company-toggle");
const followToggle = document.getElementById("follow-us-toggle");

const button = document.getElementById("btn");
const mainButton = document.getElementById("btn-main");
const mainButton2 = document.getElementById("btn-main2");
const rightLinks = document.querySelector(".nav__wrapper__right");

document.addEventListener("scroll", function () {
  if (window.scrollY > 200) {
    nav.style.position = "fixed";
    nav.style.backgroundColor = "#fffffff7";
    nav.style.boxShadow = "0px 1px 4px rgba(0, 0, 0, 0.16)";
  } else {
    nav.style.position = "absolute";
    nav.style.background = "none";
    nav.style.boxShadow = "none";
  }
});
const x = window.matchMedia("max-width:2000px");
console.log(x.addEventListener);

// our company
ourCompany.addEventListener("mouseover", () => {
  if (productsToggle.style.opacity == 1 || followToggle.style.opacity == 1) {
    productsToggle.style.opacity = 0;
    productsToggle.style.visibility = "hidden";
    productsToggle.style.transform = "translateY(10px)";
    ourProducts.style.setProperty("--db", "none");
    companyToggle.style.opacity = 1;
    companyToggle.style.visibility = "visible";
    companyToggle.style.transform = "translateY(0)";
    ourCompany.style.setProperty("--db", "block");
  } else {
    companyToggle.style.opacity = 1;
    companyToggle.style.visibility = "visible";
    companyToggle.style.transform = "translateY(0)";
    ourCompany.style.setProperty("--db", "block");
  }
});
ourCompany.addEventListener("mouseleave", () => {
  companyToggle.addEventListener("mouseleave", () => {
    setTimeout(() => {
      companyToggle.style.opacity = 0;
      companyToggle.style.visibility = "hidden";
      companyToggle.style.transform = "translateY(10px)";
      ourCompany.style.setProperty("--db", "none");
    }, 1000);
  });
});

ourCompany.addEventListener("click", () => {
  if (companyToggle.style.opacity == 1) {
    companyToggle.style.opacity = 0;
    companyToggle.style.visibility = "hidden";
    companyToggle.style.transform = "translateY(10px)";
    ourCompany.style.setProperty("--db", "none");
  } else {
    companyToggle.style.opacity = 1;
    companyToggle.style.visibility = "visible";
    companyToggle.style.transform = "translateY(0px)";
    ourCompany.style.setProperty("--db", "block");
  }
});
// follow us
followUs.addEventListener("mouseover", () => {
  if (productsToggle.style.opacity == 1 || companyToggle.style.opacity == 1) {
    productsToggle.style.opacity = 0;
    productsToggle.style.visibility = "hidden";
    productsToggle.style.transform = "translateY(10px)";
    ourProducts.style.setProperty("--db", "none");
    companyToggle.style.opacity = 0;
    companyToggle.style.visibility = "hidden";
    companyToggle.style.transform = "translateY(10px)";
    ourCompany.style.setProperty("--db", "none");
    followToggle.style.opacity = 1;
    followToggle.style.visibility = "visible";
    followToggle.style.transform = "translateY(0)";
    followUs.style.setProperty("--db", "block");
  } else {
    followToggle.style.opacity = 1;
    followToggle.style.visibility = "visible";
    followToggle.style.transform = "translateY(0)";
    followUs.style.setProperty("--db", "block");
  }
});
followUs.addEventListener("mouseleave", () => {
  followToggle.addEventListener("mouseleave", () => {
    setTimeout(() => {
      followToggle.style.opacity = 0;
      followToggle.style.visibility = "hidden";
      followToggle.style.transform = "translateY(10px)";
      followUs.style.setProperty("--db", "none");
    }, 1000);
  });
});

followUs.addEventListener("click", () => {
  if (followToggle.style.opacity == 1) {
    followToggle.style.opacity = 0;
    followToggle.style.visibility = "hidden";
    followToggle.style.transform = "translateY(10px)";
    followUs.style.setProperty("--db", "none");
  } else {
    followToggle.style.opacity = 1;
    followToggle.style.visibility = "visible";
    followToggle.style.transform = "translateY(0px)";
    followUs.style.setProperty("--db", "block");
  }
});

// our products
ourProducts.addEventListener("mouseover", () => {
  if (companyToggle.style.opacity == 1 || followToggle.style.opacity == 1) {
    companyToggle.style.opacity = 0;
    companyToggle.style.visibility = "hidden";
    companyToggle.style.transform = "translateY(10px)";
    ourCompany.style.setProperty("--db", "none");
    followToggle.style.opacity = 0;
    followToggle.style.visibility = "hidden";
    followToggle.style.transform = "translateY(10px)";
    followUs.style.setProperty("--db", "none");

    productsToggle.style.opacity = 1;
    productsToggle.style.visibility = "visible";
    productsToggle.style.transform = "translateY(0)";
    ourProducts.style.setProperty("--db", "block");
    button.style.setProperty("--trb", "translateY(8px)");
    button.style.setProperty("--rtb", "rotate(45deg)");
    button.style.setProperty("--tra", "translateY(-8px)");
    button.style.setProperty("--rta", "rotate(-45deg)");
    button.style.setProperty("--bg", "#f48225");
    button.style.background = " transparent";
  } else {
    productsToggle.style.opacity = 1;
    productsToggle.style.visibility = "visible";
    productsToggle.style.transform = "translateY(0)";
    ourProducts.style.setProperty("--db", "block");
    button.style.setProperty("--trb", "translateY(8px)");
    button.style.setProperty("--rtb", "rotate(45deg)");
    button.style.setProperty("--tra", "translateY(-8px)");
    button.style.setProperty("--rta", "rotate(-45deg)");
    button.style.setProperty("--bg", "#f48225");
    button.style.background = " transparent";
  }
});

ourProducts.addEventListener("mouseleave", () => {
  productsToggle.addEventListener("mouseleave", () => {
    setTimeout(() => {
      productsToggle.style.opacity = 0;
      productsToggle.style.visibility = "hidden";
      productsToggle.style.transform = "translateY(10px)";
      ourProducts.style.setProperty("--db", "none");
      button.style.setProperty("--trb", "translateY(0px)");
      button.style.setProperty("--rtb", "rotate(0deg)");
      button.style.setProperty("--tra", "translateY(0px)");
      button.style.setProperty("--rta", "rotate(0deg)");
      button.style.setProperty("--bg", "currentColor");
      button.style.background = "currentColor";
    }, 1000);
  });
});

ourProducts.addEventListener("click", () => {
  if (productsToggle.style.opacity == 1) {
    productsToggle.style.opacity = 0;
    productsToggle.style.visibility = "hidden";
    productsToggle.style.transform = "translateY(10px)";
    ourProducts.style.setProperty("--db", "none");
  } else {
    productsToggle.style.opacity = 1;
    productsToggle.style.visibility = "visible";
    productsToggle.style.transform = "translateY(0px)";
    ourProducts.style.setProperty("--db", "block");
  }
});

mainButton.addEventListener("click", () => {
  if (productsToggle.style.opacity == 1) {
    productsToggle.style.opacity = 0;
    productsToggle.style.visibility = "hidden";
    productsToggle.style.transform = "translateY(10px)";
    ourProducts.style.setProperty("--db", "none");
    ourProducts.style.setProperty("--db", "none");
    button.style.setProperty("--trb", "translateY(0px)");
    button.style.setProperty("--rtb", "rotate(0deg)");
    button.style.setProperty("--tra", "translateY(0px)");
    button.style.setProperty("--rta", "rotate(0deg)");
    button.style.setProperty("--bg", "currentColor");
    button.style.background = "currentColor";
  } else {
    productsToggle.style.opacity = 1;
    productsToggle.style.visibility = "visible";
    productsToggle.style.transform = "translateY(0px)";
    ourProducts.style.setProperty("--db", "block");
    button.style.setProperty("--trb", "translateY(8px)");
    button.style.setProperty("--rtb", "rotate(45deg)");
    button.style.setProperty("--tra", "translateY(-8px)");
    button.style.setProperty("--rta", "rotate(-45deg)");
    button.style.setProperty("--bg", "#f48225");
    button.style.background = " transparent";
  }
});

mainButton2.addEventListener("click", () => {
  rightLinks.classList.toggle("d-none-980");
  productsToggle.classList.toggle("p-md-static");
  productsToggle.style.opacity = 1;
  productsToggle.style.visibility = "visible";
  productsToggle.style.transform = "translateY(0)";
  ourProducts.style.setProperty("--db", "block");
});
