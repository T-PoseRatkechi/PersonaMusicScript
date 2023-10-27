<script lang="ts">
	const example1 = `
const answer = 42
const text = "question"
const songs = random_song(1, 5)
`.trim();

	const example2 = `
const customSongs = random_song(1, 6)

encounter["Yukiko's Castle"]:
  music = customSongs
end

encounter["Void Quest"]:
  music = customSongs
end

encounter["Hollow Forest"]:
  music = customSongs
end
`.trim();
</script>

<h3>Constants</h3>
<div class="row">
	<div class="column">
		<p>
			<b>Constants</b> are variables that can reused through out a script. Most useful when you're repeatedly
			using the same value.
		</p>
	</div>
	<div class="column">
		<pre><code>{example1}</code></pre>
	</div>
</div>
<h4>Using Constants</h4>
<div class="row">
	<div class="column">
		<p>
			Here, instead of copy and pasting <code>random_song(1, 6)</code> over and over again, you can give
			it a name to use instead.
		</p>
		<p>
			This also means you can make changes in one place and have it apply everywhere the constant
			was used.
		</p>
	</div>
	<div class="column"><pre><code>{example2}</code></pre></div>
</div>
