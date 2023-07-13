const more = document.querySelector(".more-button");
const morePopover = document.querySelector(
  ".container__main-content__questions__about__flex__item__filter--popover"
);

more.addEventListener("click", () => {
  morePopover.classList.toggle("display-none");
});

// filter
const filter = document.getElementById("filter");
const filterButton = document.querySelector(".filter-button");

filterButton.addEventListener("click", () => {
  filter.classList.toggle("display-none");
});

// watch

let watchInput = document.querySelector(
  ".container__main-content__right-sidebar__watch__watched  .container__main-content__right-sidebar__watch__watched__content__input"
);

const watchList = document.querySelector(
  ".container__main-content__right-sidebar__watch__watched__content__tags-list"
);
const watchNoContent = document.querySelector(
  ".container__main-content__right-sidebar__watch__watched__content__no-content"
);
const buttonX = document.querySelectorAll(".delete-tag");

const watchAddButton = document.querySelector(
  ".container__main-content__right-sidebar__watch__watched__content__no-content > a"
);

let watched = document.querySelector(
  ".container__main-content__right-sidebar__watch"
);

let watchContent = document.querySelector(
  ".container__main-content__right-sidebar__watch__watched__content"
);

let addButton = document.querySelector(
  ".container__main-content__right-sidebar__watch__watched__content__input > form > button"
);
const Addedtags = document.querySelectorAll(".container__main-content__right-sidebar__watch__watched__content__tags-list__tag")

watchAddButton.addEventListener("click", Appear);

let watchInputElement = document.getElementById("tagSearchInput");
let Edit = document.querySelector(".container__main-content__right-sidebar__watch__watched__header > a");

const WatchZone = document.getElementsByClassName("container__main-content__right-sidebar__watch__watched");


function Appear() {
  watchNoContent.classList.add("display-none");
   watchInput.classList.remove("display-none");
   watchInputElement.focus();
}

function check() {

    if (Addedtags.length > 0) {
            watchNoContent.classList.add("display-none")
     
    } else {
        if (watchNoContent.classList.contains("display-none")) {
            watchNoContent.classList.remove("display-none")
        }
    }

}
check()
function addTag() {
    let div = document.createElement("div");
    div.classList.add(
        "container__main-content__right-sidebar__watch__watched__content__tags-list__tag"
    );
    let a = document.createElement("a");
    let value = watchInputElement.value;

    a.innerText = value;

    let span = document.createElement("span");
    span.classList.add("delete-tag");

    watchList.appendChild(div);
    div.appendChild(a);
    a.appendChild(span);
    watchList.classList.remove("display-none");
}

Edit.addEventListener("click", (e) => {
    e.preventDefault();

    if (watchInput.classList.contains("display-none")) {
        watchInput.classList.remove("display-none")
    }
    if (!watchNoContent.classList.contains("display-none")) {
        watchNoContent.classList.add("display-none")
    }
})

document.addEventListener("click", (e) => {
    let inputTarget = document.getElementById("tagSearchInput");
    let buttonTarget = document.getElementById("tagAdd");
    let tags = document.querySelectorAll(".tagLi");


        
        if (e.target == inputTarget || e.target == buttonTarget || e.target == Edit || e.target==watchAddButton) {
           
        } else {
            if (!watchInput.classList.contains("display-none")) {
                watchInput.classList.add('display-none')
            }
            if (Addedtags.length > 0) {
                if (!watchNoContent.classList.contains("display-none")) {
                    watchNoContent.classList.add("display-none")
                }


            }
        }

        tags.forEach(t => {
            if (e.target == t) {
                if (watchInput.classList.contains("display-none")) {
                    watchInput.classList.remove('display-none')
                   
                }
                if (!watchNoContent.classList.contains("display-none")) {
                    watchNoContent.classList.add("display-none")
                }
            }
        })
    
})





let tagForm = document.getElementsByClassName("tagForm");

const div = document.createElement("div");
const ul = document.createElement("ul");

$(div).append(ul);

div.classList.add("ac_results");
ul.classList.add("result_ul");


watchInputElement.addEventListener("input", (e) => {
    $(ul).empty()
    let value = e.target.value;

    if (value == null || value == undefined || value == "" || value == " ") {
        div.style.display = "none"

    } else {
        ListOfTags(e,div,ul,tagForm)
    }
})


function ListOfTags(e,div,ul,form) {
    $.ajax({
        url: "/home/SearchedTags",
        method: "Post",
        dataType: 'json',
        data: {
            searchedString: e.target.value
        },
        success: function (data) {
            div.style.display = "block"
            data.forEach(e => {

                let li = document.createElement("li");
                li.classList.add("tagLi");

                $(ul).append(li);

                li.innerHTML = e;
            })

            $(form).append(div);


            ChangeValue(e)
        },
        error: function (err) {
            console.log(err);
        }
    })
}

function ChangeValue(input) {
    var returnedValue = document.querySelectorAll(".tagLi");

    returnedValue.forEach(val => {

        val.addEventListener("click", (v) => {
            let vl = v.target.innerText;
            input.target.value = vl;
        })
    })
}


addButton.addEventListener("click", (e) => {
    e.preventDefault();

    let inputResult = watchInputElement.value;
    if (watchInputElement.value !== "") {


        $.ajax({
            url: "/home/WatchTag",
            method: "Post",
            dataType: 'json',
            data: {
                data: watchInputElement.value
            },
            success: function (data) {
                let alertSpan = document.createElement("span");
                let resultDiv = document.getElementsByClassName("ac_results");
                if (data == null) {
                    alertSpan.innerText = "This tag does't exits in this site"
                    $(resultDiv).append(alertSpan)
                    setTimeout(() => {
                        $(alertSpan).remove();
                    }, 1000);
                } else if (data == false) {
                    alertSpan.innerText = "This tag already is exist in list above";
                    $(resultDiv).append(alertSpan)
                    setTimeout(() => {
                        $(alertSpan).remove();
                    }, 1000);
                }
                else {
                    addTag()
                    RemoveWatchedTag(watchList)
                }
                

                watchInputElement.value = ""
            },
            error: function (err) {
                console.log(err);
            }
        })
    }


})



// ignored






