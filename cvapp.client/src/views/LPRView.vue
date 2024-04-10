<template>
  <v-container class="fill-height">
    <v-responsive class="align-centerfill-height mx-auto" max-width="1200">
      <v-img class="mb-12" src="/assets/back.png"/>
      <div class="demo-container text-center">
        <div class="text-center">
          <h2><span>Demo</span></h2>
          <p>Try license plate recognition now by uploading a local image, or providing an image URL.</p>
          <p>This demo is built with license plate recognition API. If you have any specific technical requirements, check the index below or contact us.</p>
        </div>
        <div class="app-container d-inline-block">
          <div class="app-demo">
            <div class="image-container">
              <canvas id="myCanvas" width="530" height="500">

              </canvas>
            </div>
            <div class="sample-image-container d-inline-block">
              <a @click="selectSampleImg(0)"><img class="sample-image" :id="images[0].id" :src="images[0].src" :alt="images[0].alt" width="120" height="120"/></a>
              <a @click="selectSampleImg(1)"><img class="sample-image" :id="images[1].id" :src="images[1].src" :alt="images[1].alt" width="120" height="120"/></a>
              <a @click="selectSampleImg(2)"><img class="sample-image" :id="images[2].id" :src="images[2].src" :alt="images[2].alt" width="120" height="120"/></a>
              <a @click="selectSampleImg(3)"><img class="sample-image" :id="images[3].id" :src="images[3].src" :alt="images[3].alt" width="120" height="120"/></a>
            </div>
            <div class="app-upload-container">
              <button id="file-uploader-btn" class="upload-button" @click="uploadFile()">
                <i class="icon-upload"></i><span>Upload</span>
                <input id="image_file" type="file" accept="image/*" class="upload">
              </button>
              <div class="app-url-search">
                <input id="image_url" type="text" class="url-search-input" placeholder="Image URL">
                <button class="bg-primary url-search-button" @click="loadImgFromUrl()">Go</button>
              </div>
            </div>
          </div>
          <pre id="demo-result" class="json-container">

          </pre>
        </div>
      </div>
    </v-responsive>
  </v-container>
</template>

<script setup lang="ts">
import {prettyPrintJson} from 'pretty-print-json';
import {onBeforeMount} from 'vue'

let images = []

onBeforeMount(() => {
  const search = window.location.search;
  for (let i = 1; i < 5; i++) {
    let id = "img(0" + i + ")";
    images.push({
      'src': '/assets/products/lpr/' + search.substring(search.length - 2) + '/' + id + '.jpg',
      'alt': id + '.jpg',
      'id': id
    });
  }
})

function removeAllActive() {
  for (let i = 0; i < 4; i++) {
    let ele = document.getElementById(images[i].id);
    ele.setAttribute("class", "sample-image");
  }
}

const img = new Image();

img.onload = function () {
  let canvas = document.createElement('CANVAS')
  let ctx = canvas.getContext('2d')
  canvas.height = img.height;
  canvas.width = img.width;
  ctx.drawImage(img, 0, 0);
  const dataURL = canvas.toDataURL();
  canvas = null;

  canvas = document.getElementById("myCanvas");
  ctx = canvas.getContext("2d");

  var imgWidth = img.naturalWidth;
  var screenWidth = canvas.width;
  var imgHeight = img.naturalHeight;
  var screenHeight = canvas.height;
  var scaleX = screenWidth / imgWidth;
  var scaleY = screenHeight / imgHeight;
  var scale = scaleX < scaleY ? scaleX : scaleY;
  imgHeight = imgHeight * scale;
  imgWidth = imgWidth * scale;

  let x = 0, y = 0;
  if (imgWidth < screenWidth) {
    x = (screenWidth - imgWidth) / 2;
  } else {
    y = (screenHeight - imgHeight) / 2;
  }
  ctx.fillStyle = "#000";

  const search = window.location.search;

  var data = JSON.stringify({
    "image_base64": dataURL,
    "image_url": "",
    "country": search.substring(search.length - 2)
  });

  const fetchPromise = fetch("/api/lpr", {
    method: "POST",
    mode: "cors",
    headers: {
      "Content-Type": "application/json",
      'Access-Control-Allow-Origin': '*'
    },
    body: data,
  });

  fetchPromise
      .then((res) => res.json())
      .then(data => {
        const elem = document.getElementById('demo-result');

        elem.innerHTML = prettyPrintJson.toHtml(data);
        ctx.fillRect(0, 0, canvas.width, canvas.height);
        ctx.drawImage(img, 0, 0, img.naturalWidth, img.naturalHeight, x, y, imgWidth, imgHeight);
        for (let i = 0; i < data.carPlateData.nPlateCount; i++) {
          let left = data.carPlateData.pPlate[i].rtPlate.left * scale;
          let top = data.carPlateData.pPlate[i].rtPlate.top * scale;
          let right = data.carPlateData.pPlate[i].rtPlate.right * scale;
          let bottom = data.carPlateData.pPlate[i].rtPlate.bottom * scale;
          ctx.font = "20px Arial Bold";
          ctx.fillStyle = "green";
          ctx.fillRect(x + left - 10, y + top - 25, 15 * data.carPlateData.pPlate[i].szLicense.length + 10, 25);
          ctx.fillStyle = "black";
          ctx.fillText(data.carPlateData.pPlate[i].szLicense, x + left, y + top - 5);
          ctx.strokeStyle = "blue";
          ctx.lineWidth = 5;
          ctx.strokeRect(x + left, y + top, right - left, bottom - top);
        }
      });

}

function uploadFile() {
  const file_input = document.getElementById("image_file");
  file_input.click();
  file_input.onchange = function (e) {
    var reader = new FileReader();
    if (e.target.files[0])
      reader.readAsDataURL(e.target.files[0]);
    reader.onload = (event2) => { // called once readAsDataURL is completed
      img.src = reader.result;
    }
  }
}

function loadImgFromUrl() {
  const input = document.getElementById('image_url');
  console.log(input.value);
  const url = input.value;
  if (url) {
    img.src = url;
  }
}

function selectSampleImg(id) {
  removeAllActive();
  let ele = document.getElementById(images[id].id);
  ele.setAttribute("class", "active sample-image");
  img.src = images[id].src;
}

</script>

<style scoped lang="scss">
.demo-container h2 {
  padding-bottom: 10px;
}

.app-container {
  padding-top: 30px;
}

.app-container {
  min-width: 1200px;
  width: 1200px;
  margin: 0 auto;
  overflow: hidden;
  padding: 70px 0 82px;
}

.app-demo {
  width: 570px;
  height: 720px;
  border-radius: 4px;
  background-color: #f6f7fb;
  float: left;
  padding: 20px;
}

.json-container {
  width: 600px;
  float: right;
  vertical-align: top;
  height: 720px;
  text-align: left;
  font-size: 16px;
  overflow: auto;
  border: 2px solid #aaa;
}

p {
  font-size: 14px;
}

.image-container {
  width: 530px;
  height: 500px;
  margin: 0 auto 10px;
}

.sample-image-container {
  width: 100%;
}


.sample-image {
  margin: 0 5px;
  float: left;
}

img.active.sample-image {
  border: 2px solid #00b2e0;
}

canvas {
  width: 100%;
  height: 100%;
}

.app-upload-container {
  width: 530px;
  margin: 0 auto;
  padding: 10px 0;
  display: inline-block;
}

.upload-button {
  width: 150px;
  height: 36px;
  border-radius: 4px;
  background-color: #fff;
  border: 1px solid #bbb;
  line-height: 36px;
  text-align: center;
  font-size: 14px;
  color: #666;
  cursor: pointer;
  float: left;
}

.icon-upload {
  display: inline-block;
  background-repeat: no-repeat;
  vertical-align: middle;
  width: 20px;
  margin-right: 10px;
  height: 24px;
  margin-top: -5px;
  background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABQAAAAYCAMAAADNlS1EAAAATlBMVEUAAABZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfVZsfX1ZUpWAAAAGXRSTlMAHTxE+tZ3u4d0GRXz7NvQy7iymnBkRyUMWeYi2AAAAHtJREFUGNPFzEkShCAQRNEqugREnMe8/0UbJbpDYOfGv8u3SPrl+t5RlquAKtMmWNAmMwEk1QmyAqvHdEPbbgzw1lpKOvE/9lprXXNEvsZOHc7miPM1OgIGY0YVUY3GDEBAlX6qN/Dw/iiQmCnF2DNcPklLQEGRkJXC7BfXChBLkOk82wAAAABJRU5ErkJggg==);
}

.app-url-search {
  float: right;
  width: 350px;
}

.upload {
  display: none;
}

.url-search-input {
  padding-left: 10px;
  float: left;
  width: 260px;
  height: 36px;
  border: 1px solid #ddd;
  border-right: 0;
  background-color: #FFF;
}

.url-search-input:active, .url-search-input:focus {
  outline: none;
}

.url-search-button {
  width: 90px;
  float: left;
  height: 36px;
}
</style>
