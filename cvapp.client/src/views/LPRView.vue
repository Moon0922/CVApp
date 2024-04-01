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
              <canvas id="myCanvas" width="530" height="530">

              </canvas>
            </div>
            <div class="sample-image-container d-inline-block">
              <a @click="selectSampleImg(0)"><img class="active sample-image" :id="images[0].id" :src="images[0].src" :alt="images[0].alt" width="120" height="120"/></a>
              <a @click="selectSampleImg(1)"><img class="sample-image" :id="images[1].id" :src="images[1].src" :alt="images[1].alt" width="120" height="120"/></a>
              <a @click="selectSampleImg(2)"><img class="sample-image" :id="images[2].id" :src="images[2].src" :alt="images[2].alt" width="120" height="120"/></a>
              <a @click="selectSampleImg(3)"><img class="sample-image" :id="images[3].id" :src="images[3].src" :alt="images[3].alt" width="120" height="120"/></a>
            </div>
          </div>
          <div class="app-demo-results">

          </div>
        </div>
      </div>
    </v-responsive>
  </v-container>
</template>

<script setup lang="ts">

const images = [
  {
    src: '/assets/products/lpr/german/img(01).jpg',
    alt: "img(01).jpg",
    id: "img(01)"
  },
  {
    src: '/assets/products/lpr/german/img(02).jpg',
    alt: "img(02).jpg",
    id: "img(02)"
  },
  {
    src: '/assets/products/lpr/german/img(03).jpg',
    alt: "img(03).jpg",
    id: "img(03)"
  },
  {
    src: '/assets/products/lpr/german/img(04).jpg',
    alt: "img(04).jpg",
    id: "img(04)"
  }
]

function removeAllActive() {
  for (let i = 0; i < 4; i++) {
    let ele = document.getElementById(images[i].id);
    ele.setAttribute("class", "sample-image");
  }
}

const img = new Image();
img.onload = function() {
  const canvas = document.getElementById("myCanvas");
  const ctx = canvas.getContext("2d");

  var imgWidth = img.naturalWidth;
  var screenWidth  = canvas.width;
  var imgHeight = img.naturalHeight;
  var screenHeight = canvas.height;
  var scaleX = screenWidth/imgWidth;
  var scaleY = screenHeight/imgHeight;
  var scale = scaleY;
  if(scaleX < scaleY) scale = scaleX;
  imgHeight = imgHeight*scale;
  imgWidth = imgWidth*scale;

  let x = 0, y = 0;
  if(imgWidth < screenWidth){
    x = (screenWidth - imgWidth) / 2;
  }else{
    y = (screenHeight - imgHeight) / 2;
  }
  ctx.fillStyle = "#f6f7fb";
  ctx.fillRect(0, 0, 530, 530);
  ctx.drawImage(img, 0, 0, img.naturalWidth, img.naturalHeight, x, y, imgWidth, imgHeight);
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

.app-demo-results {
  width: 600px;
  float: right;
  vertical-align: top;
  height: 720px;
  overflow: hidden;
}

p {
  font-size: 14px;
}

.image-container {
  width: 530px;
  height: 530px;
  margin: 0 auto 20px;
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
</style>
