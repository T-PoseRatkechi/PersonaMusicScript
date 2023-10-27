<script lang="ts">
	const example1 = `
global_bgm[42]:
  music = 24
end
`.trim();
</script>

<h2>Global BGM</h2>
<p>Override a song across the entire game.</p>
<p>
	This can be used to replace normal/advantage BGM easily, randomize a specific song, have a P5R
	costume-like effect, and who knows what else.
</p>
<h3>Global BGM Block</h3>
<div class="row">
	<div class="column">
		Between the <code>[ ]</code> brackets, set the <em>Song ID</em> to replace. Then use
		<code>music</code> to set the music you want to play instead.
	</div>
	<div class="column">
		<pre><code>{example1}</code></pre>
	</div>
</div>
